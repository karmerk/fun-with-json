using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Json
{
    public sealed class JsonObject : JsonValue
    {
        private readonly List<(JsonString name, JsonValue value)> _values = new List<(JsonString name, JsonValue value)>();

        public IEnumerable<(JsonString name, JsonValue value)> Values => _values;

        public JsonObject(params (JsonString name, JsonValue value)[] values)
        {
            // entry point for new objects
            _values.AddRange(values);
        }

        public JsonObject(Json json)
        {
            json.Require('{');
            json.Next();

            while (json.Peek() != '}')
            {
                if (_values.Count > 0)
                {
                    json.Require(',');
                    json.Next();
                }

                var jsonString = new JsonString(json);

                json.Require(':');

                var jsonValue = json.Value();

                _values.Add((jsonString, jsonValue));
                json.Next();
            }

            json.Require('}');
        }

        public override string ToString() => Json(null).ToString();
        
        public Json Json(JsonOptions options)
        {
            var builder = new StringBuilder();

            builder.Append("{");

            for (int i = 0; i < _values.Count; i++)
            {
                var name = _values[i].name;
                var value = _values[i].value;

                builder.Append(name.Json(options));
                builder.Append(':');
                builder.Append(value.Json(options));

                if (i < _values.Count - 1)
                {
                    builder.Append(',');
                }
            }

            builder.Append("}");

            return builder.ToString();
        }
    }
}
