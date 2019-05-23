using Json;
using System;
using System.Linq;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {

            const string str = "{ \"Hello\" : 42 }";
            
            var obj = new JsonObject(str);
            var first = obj.Values.First();

            var name = first.name;
            var value = first.value;


            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Value: {value}");


            var number = (JsonNumber)value;
            var integer = (int)number;


            Method(number, number);



        }

        private static void Method(int integer, double @double)
        {

        }
    }
}
