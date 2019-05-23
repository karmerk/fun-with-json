using System;

namespace Json
{
    /// <summary>
    /// Represent raw json
    /// </summary>
    public class Json
    {
        internal string Raw { get; }
        internal int Position { get; set; } = 0;

        public Json(string json)
        {
            Raw = json;
        }

        internal char Peek() => Raw[Position];


        internal void Next()
        {
            const char cr = '\r';
            const char lf = '\n';
            const char whitespace = ' ';

            var length = Raw.Length;
            for (var index = Position; index < length; index++)
            {
                var character = Raw[index];

                switch (character)
                {
                    case cr:
                    case lf:
                    case whitespace:
                        // nop
                        break;
                    default:
                        Position = index;
                        return;
                }
            }

            throw new InvalidOperationException("Json ended unexpected");
        }
        internal void Require(char character)
        {
            Next();

            var next = Raw[Position];
            var match = char.ToLowerInvariant(next) == char.ToLowerInvariant(character);

            if (!match)
            {
                throw new InvalidOperationException($"Expected '{character}' character at position {Position}");
            }

            Position++;
        }
                
        public JsonValue Value()
        {
            Next();

            switch (Raw[Position])
            {
                case '{': // object start
                    return new JsonObject(this);
                case '[': // array start
                    return new JsonArray(this);
                case '"':
                    return new JsonString(this);
                case '-':
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    return new JsonNumber(this);
                case 'n': // null
                case 'N': // null
                    return new JsonNull(this);
                case 't': // true
                case 'T': // True
                    return new JsonTrue(this);
                case 'f': // false
                case 'F': // False
                    return new JsonFalse(this);
            }

            throw new InvalidOperationException($"Unexpected character '{Raw[Position]}' at position {Position}");
        }

        public override string ToString()
        {
            return Raw;
        }

        public static implicit operator Json(string json)
        {
            return new Json(json);
        }

        public Json Append(Json json)
        {
            return new Json(this.Raw + json.Raw);
        }
    }

    public class JsonOptions
    {

    }
}
