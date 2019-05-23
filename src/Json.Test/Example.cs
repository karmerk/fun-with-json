using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Json.Test
{
    [TestClass]
    public class Program
    {
        [TestMethod]
        public void Random_Test()
        {
            //var json = new Json("{ \"Property1\": true }");

            //var obj = new JsonObject(json);

            var json = new Json(TestData.Json1);

            var obj = new JsonObject(json);

            var toString = obj.ToString();

            var data = new Data()
            {
                Text = "H\\el\"lo\b",
            };

            var js = Newtonsoft.Json.JsonConvert.SerializeObject(data.Text);

            var jstr = new JsonString(data.Text);
        }

        public class Data
        {
            public string Text { get; set; }
        }


        [TestMethod]
        public void JsonNumber()
        {
            var number = new JsonNumber(13.37m);
        }

        [TestMethod]
        public void JsonObject()
        {
            var obj = new JsonObject((new JsonString("Name"), new JsonString("John")));


            B(new JsonTrue());
            B(new JsonFalse());

            var json = obj.ToString();
        }

        private void B(bool b)
        {

        }
    }
}
