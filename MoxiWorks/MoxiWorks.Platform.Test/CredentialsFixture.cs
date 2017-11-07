using NUnit.Framework;
namespace MoxiWorks.Platform.Test
{
    [TestFixture]
    class CredentialsFixture
    {
        [Test]
        public void ShouldTakeIdentifierAndSecret()
        {
    
            Assert.AreEqual(Credentials.Identifier, "foo");
            Assert.AreEqual(Credentials.Secret, "bar"); 
        }
           
    }
}
