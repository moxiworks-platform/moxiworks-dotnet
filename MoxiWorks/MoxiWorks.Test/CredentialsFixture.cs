using Xunit;
using System.Configuration;
using MoxiWorks.Platform;


namespace MoxiWorks.Test
{

     public class CredentialsFixture
     {

         public CredentialsFixture()
         {
             // lame dependency on Configuration Manager
             ConfigurationManager.AppSettings["Identifier"] = "foo";
             ConfigurationManager.AppSettings["Secret"] = "bar";
         }
    
        [Fact]
        public void ShouldTakeIdentifierAndSecret()
        {
            // lame dependency on Configuration Manager
            ConfigurationManager.AppSettings["Identifier"] = "foo";
            ConfigurationManager.AppSettings["Secret"] = "bar";
            
            Assert.Equal("foo",Credentials.Identifier);
            Assert.Equal("bar",Credentials.Secret ); 
        }
           
    }
}
