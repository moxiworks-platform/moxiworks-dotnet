namespace MoxiWorks.Platform.Test
{
    internal class Credentials
    {
        public readonly string Identifier;
        public readonly string Secret;

        public Credentials(string identifier, string secret)
        {
            this.Identifier = identifier;
            this.Secret = secret;
        }
    }
}