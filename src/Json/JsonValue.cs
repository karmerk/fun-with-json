using System.Text;

namespace Json
{
#pragma warning disable IDE1006 // Naming Styles
    public interface JsonValue
#pragma warning restore IDE1006 // Naming Styles
    {
        Json Json(JsonOptions options);
    }
}
