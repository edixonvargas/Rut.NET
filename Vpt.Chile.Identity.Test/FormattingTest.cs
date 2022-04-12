﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vpt.Chile.Identity.Test
{
    public class FormattingTest
    {
        [TestCase("22222222-2", "N", ExpectedResult = "22222222")]
        [TestCase("22222222-2", "N0", ExpectedResult = "22222222")]
        [TestCase("22222222-2", "N-1", ExpectedResult = "22222222-1")]
        [TestCase("22222222-2", "N1", ExpectedResult = "22222222")] //TODO: Check why is taking 15ms to perform this test case
        [TestCase("22222222-2", "N10", ExpectedResult = "0022222222")]
        [TestCase("22222222-2", "N15", ExpectedResult = "000000022222222")]
        public string NumberOnlyWithNZeroPadding_ShouldReturn_IntegerPart(string strRut, string format)
        {
            //Arrange
            RUT rutToTest = RUT.FromString(strRut);

            //Act
            string actual = rutToTest.ToString(format);

            //Assert
            return actual;
        }

        [TestCase("22222222-2", "This is a rut integer part: N", ExpectedResult = "This is a rut integer part: 22222222")]
        [TestCase("22222222-2", "This is a rut integer part: N0", ExpectedResult = "This is a rut integer part: 22222222")]
        [TestCase("22222222-2", "This is a rut integer part: N-1", ExpectedResult = "This is a rut integer part: 22222222-1")]
        [TestCase("22222222-2", "This is a rut integer part: N1", ExpectedResult = "This is a rut integer part: 22222222")] //TODO: Check why is taking 15ms to perform this test case
        [TestCase("22222222-2", "This is a rut integer part: N10", ExpectedResult = "This is a rut integer part: 0022222222")]
        [TestCase("22222222-2", "This is a rut integer part: N15", ExpectedResult = "This is a rut integer part: 000000022222222")]
        [TestCase("22222222-2", "This is a rut integer part ÁÉÍÓÚ áéíóú¬°|!\"#$%&/()='''?¡¿*: N15", ExpectedResult = "This is a rut integer part ÁÉÍÓÚ áéíóú¬°|!\"#$%&/()='''?¡¿*: 000000022222222")]
        public string NumberOnlyWithSpecialStrings_ShouldReplaceOk(string strRut, string format)
        {
            //Arrange
            RUT rutToTest = RUT.FromString(strRut);

            //Act
            string actual = rutToTest.ToString(format);

            //Assert
            return actual;
        }

        [TestCase("22222222-2", "'N'0", ExpectedResult = "'N'0")]
        [TestCase("22222222-2", "'N'-1", ExpectedResult = "'N'-1")]
        [TestCase("22222222-2", "'N'1", ExpectedResult = "'N'1")] //TODO: Check why is taking 15ms to perform this test case
        [TestCase("22222222-2", "'N'10", ExpectedResult = "'N'10")]
        [TestCase("22222222-2", "'N'15", ExpectedResult = "'N'15")]
        [TestCase("22222222-2", "'NS'15", ExpectedResult = "'NS'15")]
        [TestCase("22222222-2", "'SN'15", ExpectedResult = "'SN'15")]
        [TestCase("22222222-2", "'SNS'15", ExpectedResult = "'SNS'15")]
        [TestCase("22222222-2", "'SN2S'15", ExpectedResult = "'SN2S'15")]
        [TestCase("22222222-2", "''SN2S'15", ExpectedResult = "''SN2S'15")]
        [TestCase("22222222-2", "'''SN2S'15", ExpectedResult = "'''SN2S'15")]
        [TestCase("22222222-2", "'SN-1S'15", ExpectedResult = "'SN-1S'15")]
        [TestCase("22222222-2", "'SN-1S''15", ExpectedResult = "'SN-1S''15")]
        [TestCase("22222222-2", "'SN-1S'''15", ExpectedResult = "'SN-1S'''15")]
        [TestCase("22222222-2", "' N'0", ExpectedResult = "' N'0")]
        [TestCase("22222222-2", "'N '-1", ExpectedResult = "'N '-1")]
        public string NumberOnlyWithQuotedN_ShouldReturn_LiteralN(string strRut, string format)
        {
            //Arrange
            RUT rutToTest = RUT.FromString(strRut);

            //Act
            string actual = rutToTest.ToString(format);

            //Assert
            //Assert.AreEqual(expected, actual);
            return actual;
        }

        [TestCase("22222222-2", "'N1", ExpectedResult = "'22222222")]
        [TestCase("22222222-2", "N'10", ExpectedResult = "22222222'10")]
        [TestCase("22222222-2", "N''10", ExpectedResult = "22222222''10")]
        [TestCase("22222222-2", "''N1", ExpectedResult = "''22222222")]
        public string NumberOnlyWithBadQuotedN_ShouldReturn_LiteralN(string strRut, string format)
        {
            //Arrange
            RUT rutToTest = RUT.FromString(strRut);

            //Act
            string actual = rutToTest.ToString(format);

            //Assert
            //Assert.AreEqual(expected, actual);
            return actual;
        }


        [TestCase("22222222-2", "V", ExpectedResult = "2")]
        [TestCase("22222222-2", "V0", ExpectedResult = "20")]
        [TestCase("22222222-2", "V-1", ExpectedResult = "2-1")]
        [TestCase("22222222-2", "V1", ExpectedResult = "21")]
        [TestCase("22222222-2", "V10", ExpectedResult = "210")]
        [TestCase("22222222-2", "V15", ExpectedResult = "215")]
        [TestCase("22222222-2", "This is a verifier digit part: V", ExpectedResult = "This is a verifier digit part: 2")]
        [TestCase("22222222-2", "This is a verifier digit part: V0", ExpectedResult = "This is a verifier digit part: 20")]
        [TestCase("22222222-2", "This is a verifier digit part: V-1", ExpectedResult = "This is a verifier digit part: 2-1")]
        [TestCase("22222222-2", "This is a verifier digit part: V1", ExpectedResult = "This is a verifier digit part: 21")] //TODO: Check why is takiVg 15ms to perform this test case
        [TestCase("22222222-2", "This is a verifier digit part: V10", ExpectedResult = "This is a verifier digit part: 210")]
        [TestCase("22222222-2", "This is a verifier digit part: V15", ExpectedResult = "This is a verifier digit part: 215")]
        [TestCase("22222222-2", "This is a verifier digit part ÁÉÍÓÚ áéíóú¬°|!\"#$%&/()='''?¡¿*: V15", ExpectedResult = "This is a verifier digit part ÁÉÍÓÚ áéíóú¬°|!\"#$%&/()='''?¡¿*: 215")]
        [TestCase("22222222-2", "'V'0", ExpectedResult = "'V'0")]
        [TestCase("22222222-2", "'V'-1", ExpectedResult = "'V'-1")]
        [TestCase("22222222-2", "'V'1", ExpectedResult = "'V'1")] 
        [TestCase("22222222-2", "'V'10", ExpectedResult = "'V'10")]
        [TestCase("22222222-2", "'V'15", ExpectedResult = "'V'15")]
        [TestCase("22222222-2", "'VS'15", ExpectedResult = "'VS'15")]
        [TestCase("22222222-2", "'SV'15", ExpectedResult = "'SV'15")]
        [TestCase("22222222-2", "'SVS'15", ExpectedResult = "'SVS'15")]
        [TestCase("22222222-2", "'SV2S'15", ExpectedResult = "'SV2S'15")]
        [TestCase("22222222-2", "''SV2S'15", ExpectedResult = "''SV2S'15")]
        [TestCase("22222222-2", "'''SV2S'15", ExpectedResult = "'''SV2S'15")]
        [TestCase("22222222-2", "'SV-1S'15", ExpectedResult = "'SV-1S'15")]
        [TestCase("22222222-2", "'SV-1S''15", ExpectedResult = "'SV-1S''15")]
        [TestCase("22222222-2", "'SV-1S'''15", ExpectedResult = "'SV-1S'''15")]
        [TestCase("22222222-2", "' V'0", ExpectedResult = "' V'0")]
        [TestCase("22222222-2", "'V '-1", ExpectedResult = "'V '-1")]
        [TestCase("22222222-2", "'V1", ExpectedResult = "'21")]
        [TestCase("22222222-2", "V'10", ExpectedResult = "2'10")]
        [TestCase("22222222-2", "V''10", ExpectedResult = "2''10")]
        [TestCase("22222222-2", "''V1", ExpectedResult = "''21")]
        public string VerifierDigitOnly(string strRut, string format)
        {
            //Arrange
            RUT rutToTest = RUT.FromString(strRut);

            //Act
            string actual = rutToTest.ToString(format);

            //Assert
            //Assert.AreEqual(expected, actual);
            return actual;
        }

        [TestCase("22222222-2", "M", ExpectedResult = "22.222.222-2")]
        [TestCase("22222222-2", "M0", ExpectedResult = "22.222.222-20")]
        [TestCase("22222222-2", "M-1", ExpectedResult = "22.222.222-2-1")]
        [TestCase("22222222-2", "M1", ExpectedResult = "22.222.222-21")]
        [TestCase("22222222-2", "M10", ExpectedResult = "22.222.222-210")]
        [TestCase("22222222-2", "M15", ExpectedResult = "22.222.222-215")]
        [TestCase("22222222-2", "This is a verifier digit part: M", ExpectedResult = "This is a verifier digit part: 22.222.222-2")]
        [TestCase("22222222-2", "This is a verifier digit part: M0", ExpectedResult = "This is a verifier digit part: 22.222.222-20")]
        [TestCase("22222222-2", "This is a verifier digit part: M-1", ExpectedResult = "This is a verifier digit part: 22.222.222-2-1")]
        [TestCase("22222222-2", "This is a verifier digit part: M1", ExpectedResult = "This is a verifier digit part: 22.222.222-21")] //TODO: Check why is takiVg 15ms to perform this test case
        [TestCase("22222222-2", "This is a verifier digit part: M10", ExpectedResult = "This is a verifier digit part: 22.222.222-210")]
        [TestCase("22222222-2", "This is a verifier digit part: M15", ExpectedResult = "This is a verifier digit part: 22.222.222-215")]
        [TestCase("22222222-2", "This is a verifier digit part ÁÉÍÓÚ áéíóú¬°|!\"#$%&/()='''?¡¿*: M15", ExpectedResult = "This is a verifier digit part ÁÉÍÓÚ áéíóú¬°|!\"#$%&/()='''?¡¿*: 22.222.222-215")]
        [TestCase("22222222-2", "'M'0", ExpectedResult = "'M'0")]
        [TestCase("22222222-2", "'M'-1", ExpectedResult = "'M'-1")]
        [TestCase("22222222-2", "'M'1", ExpectedResult = "'M'1")]
        [TestCase("22222222-2", "'M'10", ExpectedResult = "'M'10")]
        [TestCase("22222222-2", "'M'15", ExpectedResult = "'M'15")]
        [TestCase("22222222-2", "'MS'15", ExpectedResult = "'MS'15")]
        [TestCase("22222222-2", "'SM'15", ExpectedResult = "'SM'15")]
        [TestCase("22222222-2", "'SMS'15", ExpectedResult = "'SMS'15")]
        [TestCase("22222222-2", "'SM2S'15", ExpectedResult = "'SM2S'15")]
        [TestCase("22222222-2", "''SM2S'15", ExpectedResult = "''SM2S'15")]
        [TestCase("22222222-2", "'''SM2S'15", ExpectedResult = "'''SM2S'15")]
        [TestCase("22222222-2", "'SM-1S'15", ExpectedResult = "'SM-1S'15")]
        [TestCase("22222222-2", "'SM-1S''15", ExpectedResult = "'SM-1S''15")]
        [TestCase("22222222-2", "'SM-1S'''15", ExpectedResult = "'SM-1S'''15")]
        [TestCase("22222222-2", "' M'0", ExpectedResult = "' M'0")]
        [TestCase("22222222-2", "'M '-1", ExpectedResult = "'M '-1")]
        [TestCase("22222222-2", "'M1", ExpectedResult = "'22.222.222-21")]
        [TestCase("22222222-2", "M'10", ExpectedResult = "22.222.222-2'10")]
        [TestCase("22222222-2", "M''10", ExpectedResult = "22.222.222-2''10")]
        [TestCase("22222222-2", "''M1", ExpectedResult = "''22.222.222-21")]
        public string MilesFormatPlaceholderOnly(string strRut, string format)
        {
            //Arrange
            RUT rutToTest = RUT.FromString(strRut);

            //Act
            string actual = rutToTest.ToString(format);

            //Assert
            //Assert.AreEqual(expected, actual);
            return actual;
        }
    }
}
