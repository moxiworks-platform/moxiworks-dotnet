using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MoxiWorks.Platform;
namespace MoxiWorks.Platform.Test
{
    [TestFixture]
    public class SessionFixture
    {
        [Test]
        public void ShouldBeAbleToGetInstance()
        {
            Assert.IsNotNull(Session.Instance); 
        }

        [Test]
        public void ShouldReturnTheSameCookie()
        {
            var expected = "foo1234";
            Session.Instance.Cookie = expected; 
            var actual = Session.Instance.Cookie;

            Assert.AreEqual(expected, actual);
            
        }
    }
}
    