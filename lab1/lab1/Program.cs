using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        public static void Main(string[] args)
        {
            string myHost;
            myHost = Dns.GetHostName();
            Console.WriteLine($"Имя компьютера: {myHost}");
            IPAddress address = Dns.GetHostAddresses(myHost).First<IPAddress>(f => f.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
            if (address != null)
            {
                Console.WriteLine($"Адрес: {address} Семейство: {address.AddressFamily}");
            }

            Console.ReadKey();
        }
    }
}
