﻿using System;
using System.Text;
using System.Configuration;


namespace MoxiWorks.Platform
{
    public class Credentials
    {
        public static  string Identifier  = ConfigurationManager.AppSettings["Identifier"];
        public static  string Secret = ConfigurationManager.AppSettings["Secret"];
        
        public string ToBase64()
        {
            var text = $"{Identifier}:{Secret}";
            var bytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(bytes);  
        }
        
    }
    
}