using System.Text;

namespace Json
{
    public sealed class JsonFalse : JsonValue
    {
        public JsonFalse()
        {
        }

        internal JsonFalse(Json json)
        {
            json.Require('f');
            json.Require('a');
            json.Require('l');
            json.Require('s');
            json.Require('e');
        }

        public override string ToString()
        {
            return "false";
        }

        public void ToString(StringBuilder builder)
        {
            builder.Append("false");
        }

        public static implicit operator bool(JsonFalse _)
        {
            return false;
        }

        public Json Json(JsonOptions options)
        {
            return false.ToString();
        }
    }
}
