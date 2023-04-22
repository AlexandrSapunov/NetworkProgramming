using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            using (StreamReader strr = new StreamReader(HttpWebRequest.Create(@"http://biik.ru/rasp/cg109.htm").GetResponse().GetResponseStream()))
                str = strr.ReadToEnd();
            Console.Write(str);
            Console.ReadKey();
        }
    }
}
