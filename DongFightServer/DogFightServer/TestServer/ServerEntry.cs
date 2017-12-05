using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TestServer
{
    class ServerEntry
    {
        static void Main(string[] args)
        {
            //StartServerSync();

            StartServerAsync();
        }

        //同步方法
        public static void StartServerSync()
        {
            Console.WriteLine("[TestServer]Hello World!");

            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //绑定IP,向操作系统申请IP和端口号
            IPAddress iPAddress = IPAddress.Parse("192.168.16.141");
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 5055);
            serverSocket.Bind(iPEndPoint);
            serverSocket.Listen(100);             //开始监听端口号，设置处理链接的队列，0为无限
            Socket clientSocket = serverSocket.Accept();    //接收一个客户端的连接

            //向客户端发送消息
            string msg = "你好 世界 (by [TestServer])";
            clientSocket.Send(Encoding.UTF8.GetBytes(msg));

            //接收客户端的消息
            byte[] dataBuffer = new byte[1024];
            int count = clientSocket.Receive(dataBuffer);     //返回接收了多长的数据
            string msgReceive = Encoding.UTF8.GetString(dataBuffer, 0, count);
            Console.WriteLine("[TestServer]" + msgReceive);

            clientSocket.Close();
            serverSocket.Close();

            Console.ReadKey();
        }

        //异步方法
        public static void StartServerAsync()
        {
            Console.WriteLine("[TestServer]Hello World!");

            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //绑定IP,向操作系统申请IP和端口号
            IPAddress iPAddress = IPAddress.Parse("192.168.16.141");
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 5055);
            serverSocket.Bind(iPEndPoint);
            serverSocket.Listen(100);             //开始监听端口号，设置处理链接的队列，0为无限
            Socket clientSocket = serverSocket.Accept();    //接收一个客户端的连接

            //向客户端发送消息
            string msgStr = "你好 世界 (by [TestServer])";
            clientSocket.Send(Encoding.UTF8.GetBytes(msgStr));

            //异步接收客户端的消息
            clientSocket.BeginReceive(msg.Data, msg.StartIndex, msg.RemainSize, SocketFlags.None, ReceiveCallBack, clientSocket);

            Console.ReadKey();
        }

        static byte[] dataBuffer = new byte[1024];
        static Message msg = new Message();
        static void ReceiveCallBack(IAsyncResult result)
        {
            Socket clientSocket = null;
            try
            {
                clientSocket = result.AsyncState as Socket;
                int count = clientSocket.EndReceive(result);

                if (count == 0)
                {
                    clientSocket.Close();
                    Console.WriteLine("[TestServer]客户端下线");
                    return;
                }

                //加入数据缓冲
                msg.AddCount(count);

                //string msgReceive = Encoding.UTF8.GetString(msg.Data, msg.StartIndex, msg.RemainSize);
                //Console.WriteLine("[TestServer]" + msgReceive+"["+ count + "]");

                //读取
                msg.ReadMessage();

                //回调，再继续异步接收客户端的消息
                clientSocket.BeginReceive(msg.Data, msg.StartIndex, msg.RemainSize, SocketFlags.None, ReceiveCallBack, clientSocket);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                if (clientSocket != null)
                {
                    clientSocket.Close();
                }

                throw;
            }
            finally
            {

            }
        }
    }
}
