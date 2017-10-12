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
            Identifier = identifier;
            Secret = secret;
        }

        public string ToBase64()
        {
            var text = $"{Identifier}:{Secret}";
            var bytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(bytes);  
        }

    }
}