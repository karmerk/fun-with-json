using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Json.Test
{
    [TestClass]
    public class JsonObjectTest
    {
        [TestMethod]
        public void Test()
        {
            var str = "{ \"val1\":null,\"val2\":null,\"val3\":null  }";
            var json = new Json(str);
            var obj = new JsonObject(json);
            var values = obj.Values.ToArray();

            Assert.AreEqual(3, values.Length);
            Assert.AreEqual(str.Length, json.Position);
        }

        [TestMethod]
        public void Json_Test()
        {
            var jsonObject = new JsonObject((new JsonString("Hello"), new JsonTrue()));

            var json = jsonObject.Json(new JsonOptions());
            var str = json.ToString();

        }
    }
}
