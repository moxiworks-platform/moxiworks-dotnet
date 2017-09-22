using NUnit.Framework;
namespace MoxiWorks.Platform.Test
{
    [TestFixture]
    class CredentialsFixture
    {
        [Test]
        public void ShouldTakeIdentifierAndSecret()
        {
            var cred = new Credentials("foo", "bar");
            Assert.AreEqual(cred.Identifier, "foo");
            Assert.AreEqual(cred.Secret, "bar"); 
        }
           
    }
}
