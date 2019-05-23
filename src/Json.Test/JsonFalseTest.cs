using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Json.Test
{
    [TestClass]
    public class JsonFalseTest
    {
        [TestMethod]
        [DataRow("false")]
        [DataRow("FALSE")]
        [DataRow("FaLsE")]
        public void False_Test(string json)
        {
            var @false = new JsonFalse(json);

            Assert.AreEqual(false, (bool)@false);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        [DataRow("null")]
        [DataRow("true")]
        [DataRow("{}")]
        [DataRow("[]")]
        [DataRow("\"Hello\"")]
        [DataRow("42")]
        [DataRow("13.37")]
        public void NotFalse_Test(string json)
        {
            var @false = new JsonFalse(json);
        }

        [TestMethod]
        public void JsonFalse_IsBoolean_Test()
        {
            bool boolean = new JsonFalse();

            Assert.IsFalse(boolean);
        }
    }
}
