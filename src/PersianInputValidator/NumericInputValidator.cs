
using System.Globalization;

namespace PersianInputValidator
{
    /// <summary>
    /// Validates integer and decimal numeric input containing
    /// English, Persian, or Arabic-Indic digits.
    /// </summary>
    public static class NumericInputValidator
    {
        /// <summary>
        /// Checks whether the input contains only supported digits.
        /// A leading plus or minus sign is allowed.
        /// </summary>
        public static bool IsInteger(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            string normalized = PersianDigitNormalizer.ToEnglishDigits(input);

            int startIndex = 0;

            if (normalized[0] == '+' || normalized[0] == '-')
                startIndex = 1;

            if (startIndex == normalized.Length)
                return false;

            for (int i = startIndex; i < normalized.Length; i++)
            {
                if (normalized[i] < '0' || normalized[i] > '9')
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Checks whether the input is a decimal number.
        /// A leading sign and one decimal separator (dot or comma)
        /// are allowed. Thousands separators are not supported.
        /// </summary>
        public static bool IsDecimal(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            string normalized = PersianDigitNormalizer.ToEnglishDigits(input);

            int startIndex = 0;

            if (normalized[0] == '+' || normalized[0] == '-')
                startIndex = 1;

            if (startIndex == normalized.Length)
                return false;

            bool separatorFound = false;
            bool digitFound = false;

            for (int i = startIndex; i < normalized.Length; i++)
            {
                char character = normalized[i];

                if (character >= '0' && character <= '9')
                {
                    digitFound = true;
                    continue;
                }

                if (character == '.' || character == ',')
                {
                    if (separatorFound)
                        return false;

                    separatorFound = true;
                    continue;
                }

                return false;
            }

            return digitFound;
        }
    }
}
