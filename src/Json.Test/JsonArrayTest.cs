using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System;

namespace Json.Test
{
    [TestClass]
    public class JsonArrayTest
    {
        [TestMethod]
        public void Empty_Test()
        {
            const string str = "[ ]";
            var json = new Json(str);
            
            var array = new JsonArray(json);
            var values = array.Values.ToArray();

            Assert.AreEqual(0, values.Length);
            Assert.AreEqual(json.Position, str.Length);
        }

        [TestMethod]
        public void Null_Test()
        {
            const string str = "[ null, null, null, null ,null , null]";
            var json = new Json(str);
            var array = new JsonArray(json);

            var values = array.Values.ToArray();

            Assert.AreEqual(6, values.Length);
            Assert.AreEqual(json.Position, str.Length);
            Assert.IsTrue(values.All(x => x is JsonNull));
        }

        [TestMethod]
        public void Mixed_Test()
        {
            const string str = "[ 1337, \"Hello\", 42.5]";
            var json = new Json(str);
            
            var array = new JsonArray(json);
            var values = array.Values.ToArray();

            Assert.AreEqual(3, values.Length);
            Assert.AreEqual(json.Position, str.Length);

            Assert.AreEqual(2, values.Count(x => x is JsonNumber));
            Assert.AreEqual(1, values.Count(x => x is JsonString));
            Assert.IsTrue(values[0] is JsonNumber);
            Assert.AreEqual(1337m, (values[0] as JsonNumber).Value);
            Assert.IsTrue(values[1] is JsonString);
            Assert.AreEqual("Hello", (values[1] as JsonString).Value);
            Assert.IsTrue(values[2] is JsonNumber);
            Assert.AreEqual(42.5m, (values[2] as JsonNumber).Value);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), AllowDerivedTypes =true)]
        public void NoArrayStart_Test()
        {
            const string str = "1337, \"Hello\" ]";

            var array = new JsonArray(str);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), AllowDerivedTypes = true)]
        public void NoArrayEnd_Test()
        {
            const string str = "[ 1337, \"Hello\" ";

            var array = new JsonArray(str);
        }
    }
}
