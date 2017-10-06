using System;
using NUnit.Framework;
using static NUnit.Framework.Assert;
using MoxiWorks.Platform;
using Bogus;
namespace MoxiWorks.Platform.Test
{
    [TestFixture]
    public class TaskServiceFixture
    {
        [Test]
        public void ShouldReturnATask()
        {
            var service = new MoxiWorks.Platform.TaskService(new MoxiWorksClient(new StubContextClient()));
        }

        private IContextClient GetStubClient()
        {
            throw new NotImplementedException();
        }
    }


}
