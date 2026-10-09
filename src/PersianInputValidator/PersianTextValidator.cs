
using System;

namespace PersianInputValidator
{
    /// <summary>
    /// Provides validation for Persian and other Unicode letter text.
    /// </summary>
    public static class PersianTextValidator
    {
        /// <summary>
        /// Checks that input contains only Unicode letters,
        /// optionally allowing whitespace and hyphens.
        /// Null and empty input are invalid.
        /// </summary>
        public static bool ContainsOnlyLetters(
            string input,
            bool allowWhitespace = true,
            bool allowHyphen = false)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                    continue;

                if (allowWhitespace && char.IsWhiteSpace(c))
                    continue;

                if (allowHyphen && c == '-')
                    continue;

                return false;
            }

            return true;
        }
    }
}
