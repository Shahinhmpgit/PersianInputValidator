
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PersianInputValidator.Tests
{
    [TestClass]
    public class PersianDigitNormalizerTests
    {
        [TestMethod]
        public void ToEnglishDigits_ConvertsPersianDigits()
        {
            Assert.AreEqual("1234567890",
                PersianDigitNormalizer.ToEnglishDigits("۱۲۳۴۵۶۷۸۹۰"));
        }

        [TestMethod]
        public void ToEnglishDigits_ConvertsArabicIndicDigits()
        {
            Assert.AreEqual("1234567890",
                PersianDigitNormalizer.ToEnglishDigits("١٢٣٤٥٦٧٨٩٠"));
        }

        [TestMethod]
        public void ToPersianDigits_ConvertsEnglishDigits()
        {
            Assert.AreEqual("۱۲۳۴۵۶۷۸۹۰",
                PersianDigitNormalizer.ToPersianDigits("1234567890"));
        }

        [TestMethod]
        public void ToPersianDigits_ConvertsArabicIndicDigits()
        {
            Assert.AreEqual("۱۲۳۴۵۶۷۸۹۰",
                PersianDigitNormalizer.ToPersianDigits("١٢٣٤٥٦٧٨٩٠"));
        }

        [TestMethod]
        public void Normalizer_PreservesNonDigitCharacters()
        {
            Assert.AreEqual("کد-123 A",
                PersianDigitNormalizer.ToEnglishDigits("کد-۱۲۳ A"));
        }

        [TestMethod]
        public void Normalizer_NullInputReturnsNull()
        {
            Assert.IsNull(PersianDigitNormalizer.ToEnglishDigits(null));
            Assert.IsNull(PersianDigitNormalizer.ToPersianDigits(null));
        }

        [TestMethod]
        public void Normalizer_EmptyInputReturnsEmpty()
        {
            Assert.AreEqual("", PersianDigitNormalizer.ToEnglishDigits(""));
            Assert.AreEqual("", PersianDigitNormalizer.ToPersianDigits(""));
        }

        [TestMethod]
        public void IsDigitsOnly_AcceptsEnglishDigits()
        {
            Assert.IsTrue(PersianDigitValidator.IsDigitsOnly("1234"));
        }

        [TestMethod]
        public void IsDigitsOnly_AcceptsPersianDigits()
        {
            Assert.IsTrue(PersianDigitValidator.IsDigitsOnly("۱۲۳۴"));
        }

        [TestMethod]
        public void IsDigitsOnly_AcceptsArabicIndicDigits()
        {
            Assert.IsTrue(PersianDigitValidator.IsDigitsOnly("١٢٣٤"));
        }

        [TestMethod]
        public void IsDigitsOnly_RejectsLetters()
        {
            Assert.IsFalse(PersianDigitValidator.IsDigitsOnly("12A4"));
        }

        [TestMethod]
        public void IsDigitsOnly_RejectsWhitespace()
        {
            Assert.IsFalse(PersianDigitValidator.IsDigitsOnly("12 34"));
        }

        [TestMethod]
        public void IsDigitsOnly_RejectsNull()
        {
            Assert.IsFalse(PersianDigitValidator.IsDigitsOnly(null));
        }

        [TestMethod]
        public void IsDigitsOnly_RejectsEmptyByDefault()
        {
            Assert.IsFalse(PersianDigitValidator.IsDigitsOnly(""));
        }

        [TestMethod]
        public void IsDigitsOnly_AllowsEmptyWhenConfigured()
        {
            Assert.IsTrue(
                PersianDigitValidator.IsDigitsOnly("", allowEmpty: true));
        }

        [TestMethod]
        public void IsDigitsOnly_RejectsNegativeNumbers()
        {
            Assert.IsFalse(PersianDigitValidator.IsDigitsOnly("-123"));
        }
    }
}
