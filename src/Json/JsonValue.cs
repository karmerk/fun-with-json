using System.Text;

namespace Json
{
#pragma warning disable IDE1006 // Naming Styles
    public interface JsonValue
#pragma warning restore IDE1006 // Naming Styles
    {

        void ToString(StringBuilder builder);
    }

    public static class JsonValueExtensions
    {
        public static Json Json(this JsonValue value, JsonOptions options)
        {
            return value.ToString();
        }
    }
}
