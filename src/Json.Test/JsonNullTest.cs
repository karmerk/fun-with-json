using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Json.Test
{
    [TestClass]
    public class JsonNullTest
    {
        [TestMethod]
        [DataRow("null")]
        [DataRow("NULL")]
        [DataRow("NuLl")]
        public void Null_Test(string json)
        {
            var jsonNull = new JsonNull(json);
        }

       
        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        [DataRow("true")]
        [DataRow("false")]
        [DataRow("{}")]
        [DataRow("[]")]
        [DataRow("\"Hello\"")]
        [DataRow("42")]
        [DataRow("13.37")]
        public void NotNull_Test(string json)
        {
            var jsonNull = new JsonNull(json);
        }
    }
}
