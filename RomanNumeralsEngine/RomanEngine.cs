using System.Collections.Generic;
using System.Text;

namespace RomanNumeralsEngine
{
    public class RomanEngine
    {
        public static string Macron { get; } = "\u0304";

        private class ArabicNumberRomanNumeral
        {
            public int ArabicNumber { get; }

            public string RomanNumeral { get; }

            public ArabicNumberRomanNumeral(int arabicNumber, string romanNumeral)
            {
                ArabicNumber = arabicNumber;
                RomanNumeral = romanNumeral;
            }

            public override string ToString()
            {
                return $"{ArabicNumber} = {RomanNumeral}";
            }
        }

        private readonly IEnumerable<ArabicNumberRomanNumeral> romanNumeralValues = new List<ArabicNumberRomanNumeral>
        {
            new ArabicNumberRomanNumeral(1000000, $"M{Macron}"),
            new ArabicNumberRomanNumeral(900000, $"C{Macron}M{Macron}"),
            new ArabicNumberRomanNumeral(500000, $"D{Macron}"),
            new ArabicNumberRomanNumeral(400000, $"C{Macron}D{Macron}"),
            new ArabicNumberRomanNumeral(100000, $"C{Macron}"),
            new ArabicNumberRomanNumeral(90000, $"X{Macron}C{Macron}"),
            new ArabicNumberRomanNumeral(50000, $"L{Macron}"),
            new ArabicNumberRomanNumeral(40000, $"X{Macron}L{Macron}"),
            new ArabicNumberRomanNumeral(10000, $"X{Macron}"),
            new ArabicNumberRomanNumeral(9000, $"MX{Macron}"),
            new ArabicNumberRomanNumeral(5000, $"V{Macron}"),
            new ArabicNumberRomanNumeral(4000, $"MV{Macron}"),
            new ArabicNumberRomanNumeral(1000, "M"),
            new ArabicNumberRomanNumeral(900, "CM"),
            new ArabicNumberRomanNumeral(500, "D"),
            new ArabicNumberRomanNumeral(400, "CD"),
            new ArabicNumberRomanNumeral(100, "C"),
            new ArabicNumberRomanNumeral(90, "XC"),
            new ArabicNumberRomanNumeral(50, "L"),
            new ArabicNumberRomanNumeral(40, "XL"),
            new ArabicNumberRomanNumeral(10, "X"),
            new ArabicNumberRomanNumeral(9, "IX"),
            new ArabicNumberRomanNumeral(5, "V"),
            new ArabicNumberRomanNumeral(4, "IV"),
            new ArabicNumberRomanNumeral(1, "I")
        };

        public string Convert(int toConvert)
        {
            var stringBuilder = new StringBuilder();
            ArabicToRoman(toConvert, stringBuilder);
            return stringBuilder.ToString();
        }

        private void ArabicToRoman(int toConvert, StringBuilder stringBuilder)
        {
            foreach (var romanNumeralValue in romanNumeralValues)
            {
                while (toConvert >= romanNumeralValue.ArabicNumber)
                {
                    stringBuilder.Append(romanNumeralValue.RomanNumeral);
                    toConvert -= romanNumeralValue.ArabicNumber;
                }
            }
        }

        public int Convert(string toConvert)
        {
            return RomanToArabic(toConvert);
        }

        private int RomanToArabic(string toConvert)
        {
            var result = 0;
            foreach (var romanNumeralValue in romanNumeralValues)
            {
                while (toConvert.StartsWith(romanNumeralValue.RomanNumeral))
                {
                    result += romanNumeralValue.ArabicNumber;
                    toConvert = toConvert.Substring(romanNumeralValue.RomanNumeral.Length);
                }
            }
            return string.IsNullOrEmpty(toConvert) ? result : 0;
        }
    }
}