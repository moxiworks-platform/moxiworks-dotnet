﻿using System;
using System.Text;
using System.Configuration;
 using System.Net;
 using MoxiWorks.Platform.Interfaces;


namespace MoxiWorks.Platform
{
    /// <summary>
    /// Get the application configurations for the Identifier and Secret
    /// </summary>
    public class Credentials: IMoxiWorksCredentials
    {
        public static  string Identifier  = ConfigurationManager.AppSettings["Identifier"];
        public static  string Secret = ConfigurationManager.AppSettings["Secret"];
        
        /// <summary>
        /// Generates a base 64 byte field base on the identity and secret.
        /// </summary>
        /// <returns></returns>
        public string ToBase64()
        {
            var text = $"{Identifier}:{Secret}";
            var bytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(bytes);  
        }
        
    }
    
}