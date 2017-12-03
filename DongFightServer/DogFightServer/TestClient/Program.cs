using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //StartClientSync();
            StartClientAsync();
        }

        //同步方法
        static void StartClientSync()
        {
            Console.WriteLine("[TestClient]Hello World!");

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //和服务器端建立连接
            clientSocket.Connect(IPAddress.Parse("192.168.16.141"), 5055);

            byte[] data = new byte[1024];
            int count = clientSocket.Receive(data);
            string msg = Encoding.UTF8.GetString(data, 0, count);
            Console.WriteLine("[TestClient]" + msg);

            string s = Console.ReadLine();
            clientSocket.Send(Encoding.UTF8.GetBytes(s));

            clientSocket.Close();

            Console.ReadKey();
        }

        //异步方法
        static void StartClientAsync()
        {
            Console.WriteLine("[TestClient]Hello World!");

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //和服务器端建立连接
            clientSocket.Connect(IPAddress.Parse("192.168.16.141"), 5055);

            byte[] data = new byte[1024];
            int count = clientSocket.Receive(data);
            string msg = Encoding.UTF8.GetString(data, 0, count);
            Console.WriteLine("[TestClient]" + msg);

            while(true)
            {
                string s = Console.ReadLine();
                clientSocket.Send(Encoding.UTF8.GetBytes(s));
            }

            Console.ReadKey();
            clientSocket.Close();
        }
    }
}
