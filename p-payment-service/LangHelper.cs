
using System.Resources;
using System.Reflection;
using System.Globalization;

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

            return _rm.GetString(name);
        }
        
        public static void ChangeLanguage(string language)
        {
            var cultureInfo = new CultureInfo(language);
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

        }
    }
}
