using NUnit.Framework;
using static NUnit.Framework.Assert;
using System.Linq;

namespace MoxiWorks.Platform.Test
{
    [TestFixture]
    public class ResponseFixture
    {
        
        [Test]
        public void ShouldIncludeT()
        {
            var f = new Foo();
            var r = new Response<Foo>(f);
            AreEqual(f,r.Item );
        }

        [Test]
        public void ShouldIncludeErrorMessage()
        {
            var m = new [] {"messages"};

            var message = new MoxiWorksError
            {
                Messages = m.ToList(),
                ErrorCode = "123456",
                Status = "failure"
            };
            
            var r = new Response<Foo>(null);
            r.Errors.Add(message);
            
            IsTrue(r.HasErrors);
            
        }
        
    }
    
                   
    public class Foo {}
}
