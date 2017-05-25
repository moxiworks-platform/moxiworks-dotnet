using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoxiWorks.Platform
{
    public sealed class Session
    {
        private static readonly Session instance = new Session();

        private Session() { }

        public static Session Instance
        {
            get { return instance; }
        }


        public string Cookie { get; set; }
   
    }

}
