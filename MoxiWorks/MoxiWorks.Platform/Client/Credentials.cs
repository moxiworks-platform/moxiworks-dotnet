using System.Configuration;

namespace MoxiWorks.Platform
{
    public class Credentials
    {
        public static  string Identifier  = ConfigurationManager.AppSettings["Identifier"];
        public static  string Secret = ConfigurationManager.AppSettings["Secret"];

    }
}