using System.Collections.Generic;

namespace MoxiWorks.Platform
{
    public class Response<T>
    {

        public Response(){}

        public Response(T source )
        {
            Item = source;
        }
        
      

        public T Item { get; set; }   
        
        public bool HasErrors => Errors.Count > 0;

        public List<MoxiWorksError> Errors { get; set; } = new List<MoxiWorksError>();

    }
}