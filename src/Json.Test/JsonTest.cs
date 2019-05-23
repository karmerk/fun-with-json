using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Json.Test
{
    [TestClass]
    public class JsonTest
    {
        [TestMethod]
        public void StringIsJson_Test()
        {
            Json json = "the json string";
        }

        public void Test<T>(string str) where T : JsonValue
        {
            var json = new Json(str);
            var value = json.Value();

            Assert.IsTrue(value is T);
        }

        [TestMethod]
        public void ValueArray_Test() => Test<JsonArray>("[]");

        [TestMethod]
        public void ValueObject_Test() => Test<JsonObject>("{ \"Value\":42}");

        [TestMethod]
        public void ValueNumber_Test() => Test<JsonNumber>("13.37");

        [TestMethod]
        public void ValueString_Test() => Test<JsonString>("\"Hello World\"");
               

        [TestMethod]
        public void ValueNull_Test() => Test<JsonNull>("null");

        [TestMethod]
        public void ValueTrue_Test() => Test<JsonTrue>("true");

        [TestMethod]
        public void ValueFalse_Test() => Test<JsonFalse>("false");
    }
}
