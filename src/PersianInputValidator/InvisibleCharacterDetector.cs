
namespace PersianInputValidator
{
    /// <summary>
    /// Detects Unicode control characters in text.
    /// </summary>
    public static class InvisibleCharacterDetector
    {
        /// <summary>
        /// Returns true if the input contains a Unicode control character.
        /// Null and empty inputs return false.
        /// </summary>
        public static bool ContainsControlCharacters(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            foreach (char character in input)
            {
                if (char.IsControl(character))
                    return true;
            }

            return false;
        }
    }
}
