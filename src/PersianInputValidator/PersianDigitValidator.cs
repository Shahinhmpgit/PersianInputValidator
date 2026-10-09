
namespace PersianInputValidator
{
    /// <summary>
    /// Validates strings containing only Persian, Arabic-Indic,
    /// or English digits.
    /// </summary>
    public static class PersianDigitValidator
    {
        /// <summary>
        /// Returns true when the input contains only supported digits.
        /// Null is always invalid. Empty input is invalid by default.
        /// </summary>
        public static bool IsDigitsOnly(
            string input,
            bool allowEmpty = false)
        {
            if (input == null)
                return false;

            if (input.Length == 0)
                return allowEmpty;

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                bool isEnglishDigit = c >= '0' && c <= '9';
                bool isPersianDigit = c >= '\u06F0' && c <= '\u06F9';
                bool isArabicIndicDigit = c >= '\u0660' && c <= '\u0669';

                if (!isEnglishDigit &&
                    !isPersianDigit &&
                    !isArabicIndicDigit)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
