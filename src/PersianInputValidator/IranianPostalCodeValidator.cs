
namespace PersianInputValidator
{
    /// <summary>
    /// Validates the format of Iranian postal codes.
    /// </summary>
    public static class IranianPostalCodeValidator
    {
        /// <summary>
        /// Returns true if the input contains exactly 10 digits.
        /// English, Persian, and Arabic-Indic digits are supported.
        /// This checks format only, not whether the postal code exists.
        /// </summary>
        public static bool IsValid(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length != 10)
                return false;

            string normalized =
                PersianDigitNormalizer.ToEnglishDigits(input);

            if (normalized == null)
                return false;

            for (int i = 0; i < normalized.Length; i++)
            {
                if (normalized[i] < '0' || normalized[i] > '9')
                    return false;
            }

            return true;
        }
    }
}
