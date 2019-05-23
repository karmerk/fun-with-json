using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Json.Test
{
    [TestClass]
    public class JsonNumberTest
    {
        [TestMethod]
        [DataRow("1337", 1337)]
        [DataRow("13.37", 13.37)]
        [DataRow("-13.37", -13.37)]
        public void Number_Test(string str, double value)
        {
            var @decimal = (decimal)value;

            var json = new Json(str);
            var jsonNumber = new JsonNumber(json);

            Assert.AreEqual(@decimal, jsonNumber.Value);
            Assert.AreEqual(str.TrimEnd().Length, json.Position);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        [DataRow("\"Hey\"")]
        [DataRow("Hey")]
        [DataRow("false")]
        [DataRow("true")]
        [DataRow("null")]
        [DataRow("[]")]
        [DataRow("{}")]
        public void NotNumber_Test(string str)
        {
            var json = new Json(str);
            var jsonNumber = new JsonNumber(json);
        }

        [TestMethod]
        [DataRow("1e2")]
        [DataRow("1e-2")]
        public void Parse_Test(string str)
        {
            var value = decimal.Parse(str, System.Globalization.NumberStyles.Float);

            var json = new Json(str);
            var jsonNumber = new JsonNumber(json);
        }
    }
}
