
namespace PersianInputValidator
{
    /// <summary>
    /// Validates the length of text input.
    /// </summary>
    public static class PersianInputLengthValidator
    {
        /// <summary>
        /// Checks whether the input length is within the specified range.
        /// Length is measured in .NET UTF-16 characters.
        /// Null input is invalid.
        /// </summary>
        public static bool IsLengthValid(
            string input,
            int minimumLength,
            int maximumLength)
        {
            if (input == null)
                return false;

            if (minimumLength < 0 || maximumLength < 0)
                return false;

            if (minimumLength > maximumLength)
                return false;

            return input.Length >= minimumLength
                && input.Length <= maximumLength;
        }
    }
}
