using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Json.Test
{
    [TestClass]
    public class NewtonsoftComparisonTest
    {
        /*
         * 
While everything can be escaped inside a string, only a very limited set needs to be escaped:

The representation of strings is similar to conventions used in the C family of programming languages. A string begins and ends with quotation marks. All Unicode characters may be placed within the quotation marks except for the characters that must be escaped: quotation mark, reverse solidus, and the control characters (U+0000 through U+001F).

So only ", \ and the unprintable control characters must be escaped.

        */

        [TestMethod]
        [DataRow("\" question mark", true)] // required to escape
        [DataRow("\\ reverse solidus", true)] // required to escape
        [DataRow("/ solidus", false)] // https://github.com/JamesNK/Newtonsoft.Json/blob/cc2ef36f5533d1ab21518a8e9ec5c2f74eb2fecc/Src/Newtonsoft.Json/Utilities/JavaScriptUtils.cs
        [DataRow("\b backspace", false)]
        [DataRow("\f formfeed", false)]
        [DataRow("\n newline", false)]
        [DataRow("\r carriage return", false)]
        [DataRow("\t horizontal tab", false)]
        public void StringEscape_Test(string str, bool required)
        {
            var json = new JsonString(str).ToString();
            var newton = Newtonsoft.Json.JsonConvert.SerializeObject(str);

            if (required)
            {
                Assert.AreEqual(newton, json);
            }
                        
            var ret = new JsonString(new Json(json));
            var nret = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(newton);

            Assert.AreEqual(nret, ret.Value);

            // We can deserialize json made by newton
            Newtonsoft.Json.JsonConvert.DeserializeObject<string>(json);
            new JsonString(new Json(newton));

        }


        [TestMethod]
        [DataRow(42)]
        public void Number_Integer_Test(int value)
        {
            var json = new JsonNumber(value).ToString();
            var newton = Newtonsoft.Json.JsonConvert.SerializeObject(value);

            Assert.AreEqual(newton, json);

            var ret = new JsonNumber(new Json(json));
            var nret = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(newton);

            Assert.AreEqual(nret, ret.Value);
        }

        [TestMethod]
        [DataRow(13.37)]
        public void Number_Decimal_Test(double temp)
        {
            decimal value = (decimal)temp;

            var json = new JsonNumber(value).ToString();
            var newton = Newtonsoft.Json.JsonConvert.SerializeObject(value);

            Assert.AreEqual(newton, json);

            var ret = new JsonNumber(new Json(json));
            var nret = Newtonsoft.Json.JsonConvert.DeserializeObject<decimal>(newton);

            Assert.AreEqual(nret, ret.Value);
        }
    }
}
