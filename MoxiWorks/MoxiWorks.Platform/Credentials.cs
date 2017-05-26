using System;
using System.Text;
namespace MoxiWorks.Platform
{
    public class Credentials
    {
        public readonly string Identifier;
        public readonly string Secret;

        public Credentials(string identifier, string secret)
        {
            this.Identifier = identifier;
            this.Secret = secret;
        }

        public string ToBase64()
        {
            var text = string.Format("{0}:{1}", Identifier, Secret);
            var bytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(bytes);  
        }

    }
}