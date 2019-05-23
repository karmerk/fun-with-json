using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Json.Test
{
    public static class TestData
    {
        public static readonly string Json1 = "{" +
"  \"firstName\": \"John\"," +
"  \"lastName\": \"Smith\"," +
"  \"isAlive\": true," +
"  \"age\": 27," +
"  \"address\": {" +
"    \"streetAddress\": \"21 2nd Street\"," +
"    \"city\": \"New York\"," +
"    \"state\": \"NY\"," +
"    \"postalCode\": \"10021-3100\"" +
"  }," +
"  \"phoneNumbers\": [" +
"    {" +
"      \"type\": \"home\"," +
"      \"number\": \"212 555-1234\"" +
"    }," +
"    {" +
"      \"type\": \"office\"," +
"      \"number\": \"646 555-4567\"" +
"    }," +
"    {" +
"      \"type\": \"mobile\"," +
"      \"number\": \"123 456-7890\"" +
"    }" +
"  ]," +
"  \"children\": []," +
"  \"spouse\": null" +
"}";
    }
}
