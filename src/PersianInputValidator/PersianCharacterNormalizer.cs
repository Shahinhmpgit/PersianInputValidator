
namespace PersianInputValidator
{
    /// <summary>
    /// Normalizes common Arabic characters to their Persian equivalents.
    /// </summary>
    public static class PersianCharacterNormalizer
    {
        /// <summary>
        /// Replaces Arabic Yeh with Persian Yeh and Arabic Kaf
        /// with Persian Kaf. Other characters remain unchanged.
        /// Null input returns null.
        /// </summary>
        public static string Normalize(string input)
        {
            if (input == null)
                return null;

            return input
                .Replace('\u064A', '\u06CC')
                .Replace('\u0643', '\u06A9');
        }
    }
}
