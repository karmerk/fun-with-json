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

        public override string ToString() => Json(null).ToString();

        public Json Json(JsonOptions options)
        {
            var builder = new StringBuilder();

            builder.Append('[');

            var count = _values.Count;

            if (count > 0)
            {
                for (var i = 0; i < count - 1; i++)
                {
                    builder.Append(_values[i].Json(options));
                    builder.Append(',');
                }

                builder.Append(_values[count-1].Json(options));
            }

            builder.Append(']');

            return builder.ToString();
        }
    }
}
