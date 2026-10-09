
namespace PersianInputValidator
{
    /// <summary>
    /// Validates the basic format of Iranian landline phone numbers.
    /// This class does not verify whether a number is assigned or active.
    /// </summary>
    public static class IranianLandlineValidator
    {
        /// <summary>
        /// Validates an Iranian landline number in common formats:
        /// 02112345678, 2112345678, +982112345678, or 00982112345678.
        /// Persian and Arabic-Indic digits are supported.
        /// </summary>
        public static bool IsValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            string normalized = PersianDigitNormalizer.ToEnglishDigits(input);

            if (normalized.StartsWith("+98"))
                normalized = normalized.Substring(3);
            else if (normalized.StartsWith("0098"))
                normalized = normalized.Substring(4);

            if (normalized.Length == 11 && normalized.StartsWith("0"))
                normalized = normalized.Substring(1);

            if (normalized.Length != 10)
                return false;

            if (normalized[0] < '1' || normalized[0] > '9')
                return false;

            foreach (char character in normalized)
            {
                if (character < '0' || character > '9')
                    return false;
            }

            return true;
        }
    }
}
