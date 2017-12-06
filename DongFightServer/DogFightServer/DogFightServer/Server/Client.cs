using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace DogFightServer.Server
{
    public class Client
    {
        private Socket clientSocket;
        private ServerEntry server;
        private Message msg = new Message();

        public Client() { }
        public Client(Socket clientSocket,ServerEntry server)
        {
            this.clientSocket = clientSocket;
            this.server = server;
        }

        /// <summary>
        /// 开启监听
        /// </summary>
        public void Start()
        {
            clientSocket.BeginReceive(msg.Data, msg.StartIndex, msg.RemainSize, SocketFlags.None, ReceiveCallBack, null);
        }

        private void ReceiveCallBack(IAsyncResult ar)
        {
            try
            {
                int count = clientSocket.EndReceive(ar);
                if (count == 0)
                {
                    Close();
                }

                //处理接收的数据
                msg.ReadMessage(count);

                Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Close();
            }
        }

        /// <summary>
        /// 关闭客户端
        /// </summary>
        private void Close()
        {
            if (clientSocket != null)
            {
                clientSocket.Close();
                server.RemoveClient(this);
            }
        }
    }
}
