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

        public Json Json(JsonOptions options)
        {
            return true.ToString();
        }

        public override string ToString() => Json(null).ToString();

        public static implicit operator bool(JsonTrue _)
        {
            return true;
        }

        
    }
}
