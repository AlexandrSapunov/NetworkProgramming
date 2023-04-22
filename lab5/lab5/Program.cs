using System;
using System.IO;
using System.Net;

namespace Lab5
{
    class Program
    {
        public class WebRequestGetExample
        {
            public static void Main(string[] args)
            {
                WebClient client = new WebClient();
                client.Credentials = new NetworkCredential("username", "password");
                client.DownloadFile("https://www.interestprograms.ru/content/files/sources/tcpsendfiles2_vs11.zip", "file.zip");
                Console.WriteLine("Operation completed!");
                Console.ReadKey();
            }
        }
    }
}