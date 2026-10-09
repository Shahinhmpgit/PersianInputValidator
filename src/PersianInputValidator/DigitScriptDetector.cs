
namespace PersianInputValidator
{
    /// <summary>
    /// Identifies the digit script used in a string.
    /// </summary>
    public enum DigitScript
    {
        None = 0,
        English = 1,
        Persian = 2,
        ArabicIndic = 3,
        Mixed = 4
    }

    /// <summary>
    /// Detects whether a string contains English, Persian,
    /// Arabic-Indic, or mixed digits.
    /// Non-digit characters are ignored.
    /// </summary>
    public static class DigitScriptDetector
    {
        public static DigitScript Detect(string input)
        {
            if (string.IsNullOrEmpty(input))
                return DigitScript.None;

            bool hasEnglish = false;
            bool hasPersian = false;
            bool hasArabicIndic = false;

            foreach (char c in input)
            {
                if (c >= '0' && c <= '9')
                    hasEnglish = true;
                else if (c >= '\u06F0' && c <= '\u06F9')
                    hasPersian = true;
                else if (c >= '\u0660' && c <= '\u0669')
                    hasArabicIndic = true;
            }

            int scriptCount = 0;

            if (hasEnglish) scriptCount++;
            if (hasPersian) scriptCount++;
            if (hasArabicIndic) scriptCount++;

            if (scriptCount == 0)
                return DigitScript.None;

            if (scriptCount > 1)
                return DigitScript.Mixed;

            if (hasEnglish)
                return DigitScript.English;

            if (hasPersian)
                return DigitScript.Persian;

            return DigitScript.ArabicIndic;
        }
    }
}
