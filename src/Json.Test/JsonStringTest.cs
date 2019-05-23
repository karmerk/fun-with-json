using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Json.Test
{
    [TestClass]
    public class JsonStringTest
    {

        [TestMethod]
        public void Ctor_String_Test()
        {
            var jsonString = new JsonString("Hello World");

            Assert.AreEqual("Hello World", jsonString.Value);
            Assert.AreEqual("\"Hello World\"", jsonString.Json(new JsonOptions()).ToString());
        }


        [TestMethod]
        public void Ctor_Json_Test()
        {
            var str = "\"Hello World\"";
            var json = new Json(str);
            var jsonString = new JsonString(json);

            Assert.AreEqual("Hello World", jsonString.Value);
            Assert.AreEqual("\"Hello World\"", jsonString.Json(new JsonOptions()).ToString());
        }

        public void JsonStringIsString_Test()
        {
            var jsonString = new JsonString("\"Hello world\"");
            string value = jsonString;

            Assert.AreEqual("Hello world", value);
        }


        [TestMethod]
        public void NestedJsonString_Test()
        {
            const string str = "\"Hello nested JSON: { \\\"value\\\": 42 }\"";

            var jsonString = new JsonString(new Json(str));
            var value = jsonString.Value;
            
            Assert.AreEqual("Hello nested JSON: { \"value\": 42 }", value);
        }
    }
}
