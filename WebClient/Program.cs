using System;
using System.IO;
using System.Net;

namespace WebClient
{
    class Program
    {
        private static string _baseUrl = "http://crf630/ss";
        private static string _url1 = $"{_baseUrl}/home/about";
        private static string _url2 = $"{_baseUrl}/home/contact";
        private static string _url3 = $"{_baseUrl}/HelloService.asmx/HelloWorld";

        static void Main(string[] args)
        {
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

            // SOAP call
            webRequest = (HttpWebRequest) HttpWebRequest.Create(_url3);
            webRequest.PreAuthenticate = true;
            webRequest.UnsafeAuthenticatedConnectionSharing = true;
            webRequest.Method = "POST";
            webRequest.Timeout = System.Threading.Timeout.Infinite;
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            webRequest.ContentType = "application/soap+xml";
            webRequest.ContentLength = 0;
            webRequest.KeepAlive = true;
            webRequest.Accept = "*";
            resp = webRequest.GetResponse();
            Console.WriteLine(new StreamReader(resp.GetResponseStream()).ReadToEnd());
            resp.Close();

            webRequest = (HttpWebRequest)HttpWebRequest.Create(_url3);
            webRequest.PreAuthenticate = true;
            webRequest.UnsafeAuthenticatedConnectionSharing = true;
            webRequest.Method = "POST";
            webRequest.Timeout = System.Threading.Timeout.Infinite;
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            webRequest.ContentType = "application/soap+xml";
            webRequest.ContentLength = 0;
            webRequest.KeepAlive = true;
            webRequest.Accept = "*";
            resp = webRequest.GetResponse();
            Console.WriteLine(new StreamReader(resp.GetResponseStream()).ReadToEnd());
            resp.Close();

            Console.ReadKey();

        }
    }

    static class Constants
    {
        static readonly string HelloWorldPayload = @"<?xml version=""1.0"" encoding=""utf-8""?>
<soap12:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">
  <soap12:Body>
    <HelloWorld xmlns=""http://tempuri.org/"" />
  </soap12:Body>
</soap12:Envelope>";

    }
}
