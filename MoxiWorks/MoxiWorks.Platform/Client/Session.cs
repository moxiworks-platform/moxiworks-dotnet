using System.Net;

namespace MoxiWorks.Platform
{
    /// <summary>
    /// Holds authentication data between api calls.
    /// </summary>
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
