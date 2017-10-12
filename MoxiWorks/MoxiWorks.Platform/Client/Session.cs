using System.Net;

namespace MoxiWorks.Platform
{
    public sealed class Session
    {
        private static readonly Session instance = new Session();

        private Session() { }

        public static Session Instance
        {
            get { return instance; }
        }


        public  Cookie SessionCookie{ get; set; }
        public bool IsSessionCookieSet { get { return SessionCookie != null && !SessionCookie.Expired;  } }
    }

}
