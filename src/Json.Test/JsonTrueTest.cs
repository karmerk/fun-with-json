using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Json.Test
{
    [TestClass]
    public class JsonTrueTest
    {
        [TestMethod]
        [DataRow("true")]
        [DataRow("TRUE")]
        [DataRow("TrUe")]
        public void True_Test(string json)
        {
            var jsonTrue = new JsonTrue(json);

            Assert.AreEqual(true, (bool)jsonTrue);
            Assert.AreEqual(true.ToString(), jsonTrue.Json(new JsonOptions()).ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        [DataRow("null")]
        [DataRow("false")]
        [DataRow("{}")]
        [DataRow("[]")]
        [DataRow("\"Hello\"")]
        [DataRow("42")]
        [DataRow("13.37")]
        public void NotTrue_Test(string json)
        {
            var @true = new JsonTrue(json);
        }
                
        [TestMethod]
        public void JsonTrue_IsBoolean_Test()
        {
            bool boolean = new JsonTrue();

            Assert.IsTrue(boolean);
        }
    }
}

