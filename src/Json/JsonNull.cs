using System.Text;

namespace Json
{
    public sealed class JsonNull : JsonValue
    {
        public JsonNull()
        {
        }

        public JsonNull(Json json)
        {
            json.Require('n');
            json.Require('u');
            json.Require('l');
            json.Require('l');
        }

        public override string ToString() => Json(null).ToString();

        public Json Json(JsonOptions options)
        {
            return "null";
        }
    }
}
