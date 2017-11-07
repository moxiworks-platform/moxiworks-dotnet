using System.Collections.Generic;

namespace MoxiWorks.Platform
{
    /// <summary>
    /// Generic object used to contain respones for Moxi Works API. 
    /// </summary>
    /// <typeparam name="T">the expected type returned from the api.</typeparam>
    public class Response<T>
    {

        public Response(){}

        public Response(T source )
        {
            Item = source;
        }
        /// <summary>
        /// item returned from the api call
        /// </summary>
        public T Item { get; set; }   
        
        /// <summary>
        /// Count of errors returned from the api
        /// </summary>
        public bool HasErrors => Errors.Count > 0;

        /// <summary>
        /// Collection of errors returned from the api.
        /// </summary>
        public List<MoxiWorksError> Errors { get; set; } = new List<MoxiWorksError>();

    }
}