using NUnit.Framework;

namespace MoxiWorks.Platform.Test
{
    [TestFixture]
    public class UriBuilderFixture
    {
        [Test]
        public void ShouldTakeTheUrl()
        {
            var expected = "https://api-qa.moxiworks.com/api/goo";
            var builder = new UriBuilder("/goo");
            Assert.AreEqual(expected, builder.GetUrl()); 
        }

        [Test]
        public void ShouldGenerateQueryString()
        {
            var expected = "https://api-qa.moxiworks.com/api/goo?foo=bar&ding=dong&boo=bam";

            var builder = new UriBuilder("/goo");
            builder.QueryParameters.Add("foo","bar");
            builder.QueryParameters.Add("ding","dong");
            builder.QueryParameters.Add("boo","bam");
            
            Assert.AreEqual(expected, builder.GetUrl());

        }
        
    }
}