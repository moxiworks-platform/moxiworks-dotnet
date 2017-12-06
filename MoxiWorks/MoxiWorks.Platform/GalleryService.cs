using System.Collections.Generic;
using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;

namespace MoxiWorks.Platform
{
    public class GalleryService
    {
        public IMoxiWorksClient Client { get; set; }

        public GalleryService(IMoxiWorksClient client)
        {
            Client = client; 
        }
    }
}