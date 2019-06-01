using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Json.Test
{
    [TestClass]
    public class JsonTest
    {
        public void Next_Test()
        {
            // TODO test next
        }


        [TestMethod]
        [DataRow("    a", 'a')]
        [DataRow(@"  

   a", 'a')]
        [DataRow("    A", 'a')]
        [DataRow(@"  

   A", 'a')]
        public void Require_Ok_Test(string str, char character)
        {
            var json = new Json(str);

            json.Require(character);
        }

        [TestMethod]
        public void StringIsJson_Test()
        {
            Json json = "the json string";
        }

        public void Test<T>(string str) where T : class, JsonValue
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



        [TestMethod]
        //[DataRow("[]")]
        [DataRow("{ \"Value\":42}")]
        [DataRow("13.37")]
        [DataRow("\"Hello World\"")]
        [DataRow("null")]
        [DataRow("true")]
        [DataRow("false")]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void ValueNotArray_Test(string json) => Test<JsonArray>(json);

        [TestMethod]
        [DataRow("[]")]
        //[DataRow("{ \"Value\":42}")]
        [DataRow("13.37")]
        [DataRow("\"Hello World\"")]
        [DataRow("null")]
        [DataRow("true")]
        [DataRow("false")]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void ValueNotObject_Test(string json) => Test<JsonObject>(json);

        [TestMethod]
        [DataRow("[]")]
        [DataRow("{ \"Value\":42}")]
        //[DataRow("13.37")]
        [DataRow("\"Hello World\"")]
        [DataRow("null")]
        [DataRow("true")]
        [DataRow("false")]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void ValueNotNumber_Test(string json) => Test<JsonNumber>(json);

        [TestMethod]
        [DataRow("[]")]
        [DataRow("{ \"Value\":42}")]
        [DataRow("13.37")]
        //[DataRow("\"Hello World\"")]
        [DataRow("null")]
        [DataRow("true")]
        [DataRow("false")]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void ValueNotString_Test(string json) => Test<JsonString>(json);

        [TestMethod]
        [DataRow("[]")]
        [DataRow("{ \"Value\":42}")]
        [DataRow("13.37")]
        [DataRow("\"Hello World\"")]
        //[DataRow("null")]
        [DataRow("true")]
        [DataRow("false")]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void ValueNotNull_Test(string json) => Test<JsonNull>(json);

        [TestMethod]
        [DataRow("[]")]
        [DataRow("{ \"Value\":42}")]
        [DataRow("13.37")]
        [DataRow("\"Hello World\"")]
        [DataRow("null")]
        //[DataRow("true")]
        [DataRow("false")]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void ValueNotTrue_Test(string json) => Test<JsonTrue>(json);

        [TestMethod]
        [DataRow("[]")]
        [DataRow("{ \"Value\":42}")]
        [DataRow("13.37")]
        [DataRow("\"Hello World\"")]
        [DataRow("null")]
        [DataRow("true")]
        //[DataRow("false")]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void ValueNotFalse_Test(string json) => Test<JsonFalse>(json);
    }
}
