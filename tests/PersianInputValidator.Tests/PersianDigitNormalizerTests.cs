
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
        
        [TestMethod]
        public void IsLengthValid_AcceptsLengthWithinRange()
        {
            Assert.IsTrue(
                PersianInputLengthValidator.IsLengthValid("12345", 2, 6));
        }

        [TestMethod]
        public void IsLengthValid_AcceptsMinimumBoundary()
        {
            Assert.IsTrue(
                PersianInputLengthValidator.IsLengthValid("12", 2, 6));
        }

        [TestMethod]
        public void IsLengthValid_AcceptsMaximumBoundary()
        {
            Assert.IsTrue(
                PersianInputLengthValidator.IsLengthValid("123456", 2, 6));
        }

        [TestMethod]
        public void IsLengthValid_RejectsTooShortInput()
        {
            Assert.IsFalse(
                PersianInputLengthValidator.IsLengthValid("1", 2, 6));
        }

        [TestMethod]
        public void IsLengthValid_RejectsTooLongInput()
        {
            Assert.IsFalse(
                PersianInputLengthValidator.IsLengthValid("1234567", 2, 6));
        }

        [TestMethod]
        public void IsLengthValid_RejectsNull()
        {
            Assert.IsFalse(
                PersianInputLengthValidator.IsLengthValid(null, 0, 6));
        }

        [TestMethod]
        public void IsLengthValid_AllowsEmptyWhenMinimumIsZero()
        {
            Assert.IsTrue(
                PersianInputLengthValidator.IsLengthValid("", 0, 6));
        }

        [TestMethod]
        public void IsLengthValid_RejectsNegativeMinimum()
        {
            Assert.IsFalse(
                PersianInputLengthValidator.IsLengthValid("123", -1, 6));
        }

        [TestMethod]
        public void IsLengthValid_RejectsNegativeMaximum()
        {
            Assert.IsFalse(
                PersianInputLengthValidator.IsLengthValid("123", 0, -1));
        }

        [TestMethod]
        public void IsLengthValid_RejectsMinimumGreaterThanMaximum()
        {
            Assert.IsFalse(
                PersianInputLengthValidator.IsLengthValid("123", 5, 2));
        }
        
        [TestMethod]
        public void IsRequired_AcceptsNonEmptyText()
        {
            Assert.IsTrue(
                PersianInputValidatorRules.IsRequired("سلام"));
        }

        [TestMethod]
        public void IsRequired_RejectsNull()
        {
            Assert.IsFalse(
                PersianInputValidatorRules.IsRequired(null));
        }

        [TestMethod]
        public void IsRequired_RejectsEmptyString()
        {
            Assert.IsFalse(
                PersianInputValidatorRules.IsRequired(""));
        }

        [TestMethod]
        public void IsRequired_RejectsWhitespaceOnly()
        {
            Assert.IsFalse(
                PersianInputValidatorRules.IsRequired("   "));
        }

        [TestMethod]
        public void IsRequired_AcceptsTextSurroundedByWhitespace()
        {
            Assert.IsTrue(
                PersianInputValidatorRules.IsRequired("  سلام  "));
        }
        
        [TestMethod]
        public void IranianMobileValidator_AcceptsEnglishDigits()
        {
            Assert.IsTrue(
                IranianMobileValidator.IsValid("09123456789"));
        }

        [TestMethod]
        public void IranianMobileValidator_AcceptsPersianDigits()
        {
            Assert.IsTrue(
                IranianMobileValidator.IsValid("۰۹۱۲۳۴۵۶۷۸۹"));
        }

        [TestMethod]
        public void IranianMobileValidator_AcceptsArabicIndicDigits()
        {
            Assert.IsTrue(
                IranianMobileValidator.IsValid("٠٩١٢٣٤٥٦٧٨٩"));
        }

        [TestMethod]
        public void IranianMobileValidator_RejectsShortNumber()
        {
            Assert.IsFalse(
                IranianMobileValidator.IsValid("0912345678"));
        }

        [TestMethod]
        public void IranianMobileValidator_RejectsWrongPrefix()
        {
            Assert.IsFalse(
                IranianMobileValidator.IsValid("08123456789"));
        }

        [TestMethod]
        public void IranianMobileValidator_RejectsLetters()
        {
            Assert.IsFalse(
                IranianMobileValidator.IsValid("09123ABC789"));
        }

        [TestMethod]
        public void IranianMobileValidator_RejectsWhitespace()
        {
            Assert.IsFalse(
                IranianMobileValidator.IsValid("09123 56789"));
        }

        [TestMethod]
        public void IranianMobileValidator_RejectsNullAndEmpty()
        {
            Assert.IsFalse(IranianMobileValidator.IsValid(null));
            Assert.IsFalse(IranianMobileValidator.IsValid(""));
        }
        
        [TestMethod]
        public void IranianNationalCodeValidator_AcceptsValidCode()
        {
            Assert.IsTrue(
                IranianNationalCodeValidator.IsValid("0084575948"));
        }

        [TestMethod]
        public void IranianNationalCodeValidator_AcceptsPersianDigits()
        {
            Assert.IsTrue(
                IranianNationalCodeValidator.IsValid("۰۰۸۴۵۷۵۹۴۸"));
        }

        [TestMethod]
        public void IranianNationalCodeValidator_AcceptsArabicIndicDigits()
        {
            Assert.IsTrue(
                IranianNationalCodeValidator.IsValid("٠٠٨٤٥٧٥٩٤٨"));
        }

        [TestMethod]
        public void IranianNationalCodeValidator_RejectsInvalidChecksum()
        {
            Assert.IsFalse(
                IranianNationalCodeValidator.IsValid("0084575943"));
        }

        [TestMethod]
        public void IranianNationalCodeValidator_RejectsRepeatedDigits()
        {
            Assert.IsFalse(
                IranianNationalCodeValidator.IsValid("1111111111"));
        }

        [TestMethod]
        public void IranianNationalCodeValidator_RejectsWrongLength()
        {
            Assert.IsFalse(
                IranianNationalCodeValidator.IsValid("123456789"));
        }

        [TestMethod]
        public void IranianNationalCodeValidator_RejectsLetters()
        {
            Assert.IsFalse(
                IranianNationalCodeValidator.IsValid("00845759A2"));
        }

        [TestMethod]
        public void IranianNationalCodeValidator_RejectsNullAndEmpty()
        {
            Assert.IsFalse(
                IranianNationalCodeValidator.IsValid(null));

            Assert.IsFalse(
                IranianNationalCodeValidator.IsValid(""));
        }




    }
}
