using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using Xunit; 
using System.Threading.Tasks; 
using MoxiWorks.Platform;
using MoxiWorks.Platform.Interfaces;

namespace MoxiWorks.Test.Client
{
    public class MoxiWorksCredentials
    {
        [Fact]
        public async System.Threading.Tasks.Task ShouldBeAbleToUseOtherCredentialsClass()
        {
//            ConfigurationManager.AppSettings["MoxiWorksApiHost"] = <api url> "https://api-qa.moxiworks.com/api/";
//            ConfigurationManager.AppSettings["Identifier"] = <Identifier> "5d39ba58-bfc3-11e5-a4e3-d0e1408e8026";
//            ConfigurationManager.AppSettings["Secret"] = <"Secret"> "a56sthhidTlUsLyp8eFZBQtt";
//            var service = new CompanyService(new MoxiWorksClient());
//     
//            var response =  await service.GetCompanyAsync("windermere");
//            
//            Assert.IsType<Company>(response.Item);  
        }
        
    }

    public class TestCredentials : IMoxiWorksCredentials
    {
        public string ToBase64()
        {
            var Identifier = "5d39ba58-bfc3-11e5-a4e3-d0e1408e8026";
            var Secret = "a56sthhidTlUsLyp8eFZBQtt"; 
            var text = $"{Identifier}:{Secret}";
            var bytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(bytes);  
        }
    }
    
    
}