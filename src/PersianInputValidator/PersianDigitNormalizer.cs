
using System;

namespace PersianInputValidator
{
    /// <summary>
    /// Converts Persian, Arabic-Indic, and English digits.
    /// </summary>
    public static class PersianDigitNormalizer
    {
        /// <summary>
        /// Converts Persian and Arabic-Indic digits to English digits.
        /// Other characters remain unchanged.
        /// </summary>
        public static string ToEnglishDigits(string input)
        {
            if (input == null)
                return null;

            char[] chars = input.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] >= '\u06F0' && chars[i] <= '\u06F9')
                {
                    chars[i] = (char)(chars[i] - '\u06F0' + '0');
                }
                else if (chars[i] >= '\u0660' && chars[i] <= '\u0669')
                {
                    chars[i] = (char)(chars[i] - '\u0660' + '0');
                }
            }

            return new string(chars);
        }

        /// <summary>
        /// Converts English and Arabic-Indic digits to Persian digits.
        /// Other characters remain unchanged.
        /// </summary>
        public static string ToPersianDigits(string input)
        {
            if (input == null)
                return null;

            char[] chars = input.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] >= '0' && chars[i] <= '9')
                {
                    chars[i] = (char)(chars[i] - '0' + '\u06F0');
                }
                else if (chars[i] >= '\u0660' && chars[i] <= '\u0669')
                {
                    chars[i] = (char)(chars[i] - '\u0660' + '\u06F0');
                }
            }

            return new string(chars);
        }
    }
}
