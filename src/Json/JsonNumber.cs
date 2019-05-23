using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Json
{
    public sealed class JsonNumber : JsonValue
    {
        public decimal Value { get; }

        public JsonNumber(decimal value)
        {
            Value = value;
        }

        public JsonNumber(int value)
        {
            Value = value;
        }

        public JsonNumber(double value)
        {
            Value = (decimal)value;
        }

        public JsonNumber(Json json)
        {
            var characters = "0123456789.-+Ee".ToCharArray();
            var count = 0;
            var index = json.Position;
            var length = json.Raw.Length;

            while(index < length && characters.Contains(json.Raw[index]))
            {
                count++;
                index++;
            }

            var str = json.Raw.Substring(json.Position, count);
            var value = decimal.Parse(str, NumberStyles.Float, CultureInfo.InvariantCulture);

            Value = value;

            json.Position = index;
        }

        public override string ToString() => Json(null).ToString();

        public static implicit operator int(JsonNumber jsonNumber)
        {
            return (int)jsonNumber.Value;
        }

        public static implicit operator double(JsonNumber jsonNumber)
        {
            return (double)jsonNumber.Value;
        }

        public static implicit operator decimal(JsonNumber jsonNumber)
        {
            return jsonNumber.Value;
        }

        public Json Json(JsonOptions options)
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
