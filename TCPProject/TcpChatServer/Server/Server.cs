using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpChatServer.Server
{
    public class Server
    {
        public ServerInfo HostInfo = new ServerInfo();
        private TcpListener tcpListener;
        private Thread thread;

        public bool IsEnable { get; private set; }
        public static List<Client> Clients { get; private set; }


        public Server(string ip,int port)
        {
            if (Clients == null)
                Clients = new List<Client>();
            HostInfo.Port = port;
            thread = new Thread(LoopGetData);
            //IPAddress ipAddres = IPAddress.Parse(HostInfo.Ip);
            //IPEndPoint ipHostEndPoint = new IPEndPoint(ipAddres, HostInfo.Port);
            tcpListener = new TcpListener(IPAddress.Any,HostInfo.Port);
            HostInfo.Ip = tcpListener.LocalEndpoint;
        }

        private void LoopGetData()
        {
            while (IsEnable)
            {
                try
                {
                    var clientSocket = tcpListener.AcceptTcpClient();
                    var client = new Client(clientSocket);
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error connection: {ex.Message}");
                    break;
                }
            }
        }

        public void SendMessage(string msg)
        {
            foreach (var client in Clients)
                client.SendMessage("Server", msg);
        }

        public void Start()
        {
            IsEnable = true;
            tcpListener.Start();
            thread.Start();
            Console.WriteLine($"Server is started on {HostInfo.Ip}");
        }

        public void Stop()
        {
            IsEnable = false;
        }

    }
}
