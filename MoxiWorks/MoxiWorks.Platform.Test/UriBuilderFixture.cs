using NUnit.Framework;

namespace MoxiWorks.Platform.Test
{
    [TestFixture]
    public class UriBuilderFixture
    {
        [Test]
        public void ShouldTakeTheUrl()
        {
            var expected = "http://foo.bar@example.com/goo";
            var builder = new UriBuilder(expected);
            Assert.AreEqual(expected, builder.GetUrl()); 
        }

        [Test]
        public void ShouldGenerateQueryString()
        {
            var expected = "http://foo.bar@example.com/goo?foo=bar&ding=dong&boo=bam";

            var builder = new UriBuilder("http://foo.bar@example.com/goo");
            builder.QueryParameters.Add("foo","bar");
            builder.QueryParameters.Add("ding","dong");
            builder.QueryParameters.Add("boo","bam");
            
            Assert.AreEqual(expected, builder.GetUrl());

        }
        
    }
}