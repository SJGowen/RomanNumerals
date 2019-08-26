using RomanNumeralsEngine;
using Xunit;

namespace RomanNumeralsTest
{
    public class RomanNumeralsTest
    {
        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        public void Theory1To5Conversion(int arabic, string roman)
        {
            var engine = new RomanEngine();
            Assert.Equal(roman, engine.Convert(arabic));
            Assert.Equal(arabic, engine.Convert(roman));
        }

        [Theory]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(8, "VIII")]
        [InlineData(9, "IX")]
        [InlineData(10, "X")]
        [InlineData(11, "XI")]
        [InlineData(12, "XII")]
        public void Theory6To12Conversion(int arabic, string roman)
        {
            var engine = new RomanEngine();
            Assert.Equal(roman, engine.Convert(arabic));
            Assert.Equal(arabic, engine.Convert(roman));
        }

        [Theory]
        [InlineData(22, "XXII")]
        [InlineData(207, "CCVII")]
        [InlineData(1066, "MLXVI")]
        [InlineData(1758, "MDCCLVIII")]
        [InlineData(1904, "MCMIV")]
        [InlineData(1954, "MCMLIV")]
        [InlineData(1990, "MCMXC")]
        [InlineData(2014, "MMXIV")]
        [InlineData(9000, "MX^")]
        [InlineData(1550000, "M^D^L^")]
        [InlineData(3472618, "M^M^M^C^D^L^X^X^MMDCXVIII")]
        public void TheoryRandomConversion(int arabic, string roman)
        {
            var engine = new RomanEngine();
            roman = roman.Replace("^", RomanEngine.Macron);
            Assert.Equal(roman, engine.Convert(arabic));
            Assert.Equal(arabic, engine.Convert(roman));
        }

        [Theory]
        [InlineData(0, "MLXVAIII")]
        public void TheoryErrorConversion(int arabic, string roman)
        {
            var engine = new RomanEngine();
            Assert.Equal(arabic, engine.Convert(roman));
        }
    }
}
