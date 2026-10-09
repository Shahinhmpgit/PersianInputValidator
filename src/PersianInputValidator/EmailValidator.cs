
using System;
using System.Net.Mail;

namespace PersianInputValidator
{
    /// <summary>
    /// Provides basic email address validation.
    /// </summary>
    public static class EmailValidator
    {
        /// <summary>
        /// Checks whether the input can be parsed as a single email address.
        /// This does not verify mailbox existence or deliverability.
        /// </summary>
        public static bool IsValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            if (!string.Equals(input, input.Trim(), StringComparison.Ordinal))
                return false;

            try
            {
                var address = new MailAddress(input);

                return string.Equals(
                    address.Address,
                    input,
                    StringComparison.OrdinalIgnoreCase);
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
