
using System;
using System.Text;

namespace PersianInputValidator
{
    /// <summary>
    /// Provides basic whitespace normalization for text input.
    /// </summary>
    public static class PersianTextNormalizer
    {
        /// <summary>
        /// Trims leading and trailing whitespace and replaces each
        /// consecutive whitespace sequence with a single regular space.
        /// Null input returns null.
        /// </summary>
        public static string NormalizeWhitespace(string input)
        {
            if (input == null)
                return null;

            StringBuilder result = new StringBuilder(input.Length);
            bool pendingSpace = false;

            foreach (char c in input)
            {
                if (char.IsWhiteSpace(c))
                {
                    if (result.Length > 0)
                        pendingSpace = true;

                    continue;
                }

                if (pendingSpace)
                {
                    result.Append(' ');
                    pendingSpace = false;
                }

                result.Append(c);
            }

            return result.ToString();
        }
    }
}
