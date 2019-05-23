using System;
using System.Collections.Generic;
using System.Text;

namespace Json
{
    public class JsonArray : JsonValue
    {
        private readonly List<JsonValue> _values = new List<JsonValue>();

        public IEnumerable<JsonValue> Values => _values;

        public JsonArray(params JsonValue[] values)
        {
            _values.AddRange(values);
        }

        public JsonArray(Json json)
        {
            json.Require('[');
            json.Next();

            while (json.Peek() != ']' )
            {
                if (_values.Count > 0)
                {
                    json.Require(',');
                }

                var value = json.Value();

                _values.Add(value);

                json.Next();
            }

            json.Require(']');
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            ToString(builder);

            return builder.ToString();
        }

        public void ToString(StringBuilder builder)
        {
            builder.Append('[');

            var count = _values.Count;

            if (count > 0)
            {
                for (var i = 0; i < count - 1; i++)
                {
                    _values[i].ToString(builder);

                    builder.Append(',');
                }

                _values[count-1].ToString(builder);
            }

            builder.Append(']');
        }
    }
}
