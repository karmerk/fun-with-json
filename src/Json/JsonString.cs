using System;
using System.Collections.Generic;
using System.Text;

namespace Json
{
    public sealed class JsonString : JsonValue
    {
        private const char QuotationMark = '"';
        private const char ReverseSolidus = '\\';
        private const char Solidus = '/';
        private const char Backspace = '\b';
        private const char Formfeed = '\f';
        private const char Newline = '\n';
        private const char CarriageReturn = '\r';
        private const char HorizontalTab = '\t';

        public string Value { get; }

        public JsonString(string value)
        {
            Value = value;
            // Entry point for new string
        }

        private char Escape(char character)
        {
            switch (character)
            {
                case '"':
                case '\\':
                case '/':
                    return character;
                case 'b':
                    return '\b';
                case 'f':
                    return '\f';
                case 'n':
                    return '\n';
                case 'r':
                    return '\r';
                case 't':
                    return '\t';
                case 'u':
                    // TODO: unicode stuff
                    throw new NotSupportedException("Computer says no to unicode");
                default:
                    throw new NotSupportedException("Computer says no");
            }
        }

        public JsonString(Json json)
        {
            json.Require('"');
            
            var builder = new StringBuilder();
            
            while (json.Peek() != '"')
            {
                var character = json.Peek();
                if (character == '\\')
                {
                    json.Position++;

                    var next = json.Peek();

                    character = Escape(next);
                }

                builder.Append(character);
                json.Position++;
            }

            Value = builder.ToString();
            
            json.Require('"');
        }
               

        public override string ToString()
        {
            var builder = new StringBuilder();

            ToString(builder);

            return builder.ToString();
        }

        public void ToString(StringBuilder builder)
        {
            // TODO control character is not allowed

            builder.Append('\"');
            foreach (char character in Value)
            {
                if (character == '\\' || character == '"')
                {
                    builder.Append('\\');
                }

                builder.Append(character);
            }

            builder.Append('\"');
        }

        public static implicit operator string(JsonString value)
        {
            return value.Value;
        }
    }
}
