using System;

namespace MoxiWorks.Platform
{
    public class UnableToDeserializeException : Exception
    {
        public readonly string Data;  
        public UnableToDeserializeException(string data, Exception e, string message ="Unable to deserialize string as json."):
            base(message,e)
        {
            Data = data; 
        }
    }
}
