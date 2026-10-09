
namespace PersianInputValidator
{
    /// <summary>
    /// Validates Iranian mobile numbers in the standard 11-digit format.
    /// Accepted input digits: English, Persian, and Arabic-Indic.
    /// </summary>
    public static class IranianMobileValidator
    {
        /// <summary>
        /// Returns true for numbers matching the format 09xxxxxxxxx.
        /// Digit scripts may be mixed. Separators and whitespace are not accepted.
        /// </summary>
        public static bool IsValid(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length != 11)
                return false;

            string normalized =
                PersianDigitNormalizer.ToEnglishDigits(input);

            if (normalized == null)
                return false;

            if (!normalized.StartsWith("09"))
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
