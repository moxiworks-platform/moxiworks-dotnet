
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoxiWorks.Platform
{
    public class UriBuilder
    {
        
        public Dictionary<string, string> QueryParameters { get; } =  new Dictionary<string, string>(); 
        private Uri Host { get; } 

        public  UriBuilder(string address)
        {
            Host = new Uri(address); 
           
        }

        public string GetUrl()
        {
            return Host + BuildQueryString();
        }

        public string BuildQueryString()
        {
            if (QueryParameters.Count <= 0)
            return string.Empty;
                
                
            return "?" + string.Join("&", QueryParameters.Select(q => $"{  HttpUtility.UrlEncode(q.Key)}={HttpUtility.UrlEncode(q.Value)}"));
        }

        public void AddQueryParameter(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(value))
            {
                return; 
            }
            
            QueryParameters.Add(key,value);
        }

        public void AddQueryParameter(string key, int? value)
        {
            if (string.IsNullOrWhiteSpace(key) || ! value.HasValue)
            {
                return; 
            }
            
            QueryParameters.Add(key,value.Value.ToString());
        }
        
        
        
        
        
    }
}