
namespace PersianInputValidator
{
    /// <summary>
    /// Validates the format and checksum of Iranian national codes.
    /// This does not verify whether a code has actually been issued.
    /// </summary>
    public static class IranianNationalCodeValidator
    {
        /// <summary>
        /// Returns true if the input is a 10-digit Iranian national code
        /// with a valid checksum. Persian, Arabic-Indic, and English
        /// digits are supported.
        /// </summary>
        public static bool IsValid(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length != 10)
                return false;

            string code =
                PersianDigitNormalizer.ToEnglishDigits(input);

            if (code == null)
                return false;

            for (int i = 0; i < code.Length; i++)
            {
                if (code[i] < '0' || code[i] > '9')
                    return false;
            }

            bool allDigitsEqual = true;

            for (int i = 1; i < code.Length; i++)
            {
                if (code[i] != code[0])
                {
                    allDigitsEqual = false;
                    break;
                }
            }

            if (allDigitsEqual)
                return false;

            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += (code[i] - '0') * (10 - i);
            }

            int remainder = sum % 11;
            int checkDigit = code[9] - '0';

            if (remainder < 2)
                return checkDigit == remainder;

            return checkDigit == 11 - remainder;
        }
    }
}
