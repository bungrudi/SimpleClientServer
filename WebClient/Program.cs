using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebClient
{
    class Program
    {
        private static string _url1;
        private static string _url2;

        static void Main(string[] args)
        {
            _url1 = "http://crf630/ss/home/about";
            var webRequest = (HttpWebRequest)HttpWebRequest.Create(_url1);
            
            webRequest.PreAuthenticate = true;
            webRequest.UnsafeAuthenticatedConnectionSharing = true;
            webRequest.Method = "GET";
            webRequest.Timeout = System.Threading.Timeout.Infinite;
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            webRequest.ContentType = "text/html";
            webRequest.KeepAlive = true;
            webRequest.Accept = "*";
            var resp = webRequest.GetResponse();
            Console.WriteLine(new StreamReader(resp.GetResponseStream()).ReadToEnd());
            resp.Close();

            _url2 = "http://crf630/ss/home/contact";
            webRequest = (HttpWebRequest)HttpWebRequest.Create(_url2);
            webRequest.PreAuthenticate = true;
            webRequest.UnsafeAuthenticatedConnectionSharing = true;
            webRequest.Method = "GET";
            webRequest.Timeout = System.Threading.Timeout.Infinite;
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            webRequest.ContentType = "text/html";
            webRequest.KeepAlive = true;
            webRequest.Accept = "*";
            resp = webRequest.GetResponse();
            Console.WriteLine(new StreamReader(resp.GetResponseStream()).ReadToEnd());
            resp.Close();
            Console.ReadKey();

        }
    }
}
