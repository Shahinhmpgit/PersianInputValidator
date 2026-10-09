
namespace PersianInputValidator
{
    /// <summary>
    /// Provides common text input validation rules.
    /// </summary>
    public static class PersianInputValidatorRules
    {
        /// <summary>
        /// Returns true when input contains at least one
        /// non-whitespace character.
        /// Null, empty, and whitespace-only inputs are invalid.
        /// </summary>
        public static bool IsRequired(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
    }
}
