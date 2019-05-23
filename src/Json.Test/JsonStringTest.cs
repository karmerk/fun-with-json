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
            var json = jsonString.ToString();

            Assert.AreEqual("Hello World", jsonString.Value);
            Assert.AreEqual("\"Hello World\"", json);
        }


        [TestMethod]
        public void Ctor_Json_Test()
        {
            var str = "\"Hello World\"";
            var json = new Json(str);
            var jsonString = new JsonString(json);

            Assert.AreEqual("Hello World", jsonString.Value);
            Assert.AreEqual("\"Hello World\"", jsonString.ToString());
        }

        public void JsonStringIsString_Test()
        {
            var js = new JsonString("\"Hello world\"");

            string value = js;

            Assert.AreEqual("Hello world", value);
        }


        [TestMethod]
        public void NestedJsonString_Test()
        {
            const string str = "\"Hello nested JSON: { \\\"value\\\": 42 }\"";

            var js = new JsonString(new Json(str));
            var value = js.Value;
            
            Assert.AreEqual("Hello nested JSON: { \"value\": 42 }", value);
        }
    }
}
