
using System.Resources;
using System.Reflection;
using System.Globalization;
using System;

namespace p_payment_service
{
    public static class LangHelper
    {
        private static ResourceManager _rm;

        static LangHelper()
        {
            _rm = new ResourceManager("p_payment_service.Language.strings", Assembly.GetExecutingAssembly());

        }
        public static string GetString(string name)
        {

            var rawString = _rm.GetString(name);
            return ReplaceNewLines(rawString);
        }
        private static string ReplaceNewLines(string input)
        {
            // Replace any occurrences of "\n" with the actual newline character.
            return input?.Replace("\\n", Environment.NewLine);
        }
        public static void ChangeLanguage(string language)
        {
            var cultureInfo = new CultureInfo(language);
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

        }
    }
}
