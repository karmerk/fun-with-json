using System.Text;

namespace Json
{
    /// <summary>
    /// Represent a true value in json
    /// </summary>
    public sealed class JsonTrue : JsonValue
    {
        public JsonTrue()
        {
        }

        internal JsonTrue(Json json)
        {
            json.Require('t');
            json.Require('r');
            json.Require('u');
            json.Require('e');
        }

        public override string ToString()
        {
            return "true";
        }

        public void ToString(StringBuilder builder)
        {
            builder.Append("true");
        }

        public static implicit operator bool(JsonTrue _)
        {
            return true;
        }

        public Json Json(JsonOptions options)
        {
            return true.ToString();
        }
    }
}
