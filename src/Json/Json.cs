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
        
        //public T Value<T>() where T : class, JsonValue
        //{
        //    var type = typeof(T);

        //    switch (Raw[Position])
        //    {
        //        case '{' when type == typeof(JsonObject): // object start
        //            return new JsonObject(this) as T;
        //        case '[' when type == typeof(JsonArray): // array start
        //            return new JsonArray(this) as T;
        //        case '"' when type == typeof(JsonString):
        //            return new JsonString(this) as T;
        //        case '-' when type == typeof(JsonNumber):
        //        case '0' when type == typeof(JsonNumber):
        //        case '1' when type == typeof(JsonNumber):
        //        case '2' when type == typeof(JsonNumber):
        //        case '3' when type == typeof(JsonNumber):
        //        case '4' when type == typeof(JsonNumber):
        //        case '5' when type == typeof(JsonNumber):
        //        case '6' when type == typeof(JsonNumber):
        //        case '7' when type == typeof(JsonNumber):
        //        case '8' when type == typeof(JsonNumber):
        //        case '9' when type == typeof(JsonNumber):
        //            return new JsonNumber(this) as T;
        //        case 'n' when type == typeof(JsonNull): // null
        //        case 'N' when type == typeof(JsonNull): // null
        //            return new JsonNull(this) as T;
        //        case 't' when type == typeof(JsonTrue): // true
        //        case 'T' when type == typeof(JsonTrue): // True
        //            return new JsonTrue(this) as T;
        //        case 'f' when type == typeof(JsonFalse): // false
        //        case 'F' when type == typeof(JsonFalse): // False
        //            return new JsonFalse(this) as T;
        //    }

        //    throw new InvalidOperationException($"Unexpected character '{Raw[Position]}' at position {Position}");
        //}

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
