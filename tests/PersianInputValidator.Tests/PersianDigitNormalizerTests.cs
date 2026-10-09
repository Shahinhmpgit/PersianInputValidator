
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersianInputValidator;

namespace PersianInputValidator.Tests
{
    [TestClass]
    public class PersianDigitNormalizerTests
    {
        [TestMethod]
        public void ToEnglishDigits_ConvertsPersianDigits()
        {
            Assert.AreEqual("123", PersianDigitNormalizer.ToEnglishDigits("۱۲۳"));
        }

        [TestMethod]
        public void ToEnglishDigits_ConvertsArabicIndicDigits()
        {
            Assert.AreEqual("123", PersianDigitNormalizer.ToEnglishDigits("١٢٣"));
        }

        [TestMethod]
        public void ToPersianDigits_ConvertsEnglishDigits()
        {
            Assert.AreEqual("۱۲۳", PersianDigitNormalizer.ToPersianDigits("123"));
        }

        [TestMethod]
        public void ToPersianDigits_ConvertsArabicIndicDigits()
        {
            Assert.AreEqual("۱۲۳", PersianDigitNormalizer.ToPersianDigits("١٢٣"));
        }

        [TestMethod]
        public void Conversion_PreservesOtherCharacters()
        {
            Assert.AreEqual(
                "شماره 123-A",
                PersianDigitNormalizer.ToEnglishDigits("شماره ۱۲۳-A"));
        }

        [TestMethod]
        public void Conversion_ReturnsNullForNullInput()
        {
            Assert.IsNull(PersianDigitNormalizer.ToEnglishDigits(null));
            Assert.IsNull(PersianDigitNormalizer.ToPersianDigits(null));
        }

        [TestMethod]
        public void Conversion_HandlesEmptyString()
        {
            Assert.AreEqual("", PersianDigitNormalizer.ToEnglishDigits(""));
            Assert.AreEqual("", PersianDigitNormalizer.ToPersianDigits(""));
        }
    }
}
