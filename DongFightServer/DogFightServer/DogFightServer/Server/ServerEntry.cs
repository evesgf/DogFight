using Common;
using DogFightServer.Controller;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DogFightServer.Server
{
    public class ServerEntry
    {
        private IPEndPoint iPEndPoint;
        private Socket serverSocket;
        private List<Client> clientList;
        private ControllerManager controllerManager;

        public ServerEntry() { }

        public ServerEntry(string ipStr, int point)
        {
            controllerManager = new ControllerManager(this);
            SetIpAndPort(ipStr, point);
        }

        public void SetIpAndPort(string ipStr, int point)
        {
            iPEndPoint = new IPEndPoint(IPAddress.Parse(ipStr), point);
        }

        /// <summary>
        /// 启动服务器
        /// </summary>
        public void Start()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(iPEndPoint);
            serverSocket.Listen(0);
            serverSocket.BeginAccept(AcceptCallBack, null);
        }

        private void AcceptCallBack(IAsyncResult ar)
        {
            Socket clientSocket = serverSocket.EndAccept(ar);
            Client client = new Client(clientSocket,this);
            client.Start();
            clientList.Add(client);
        }

        public void RemoveClient(Client client)
        {
            lock (clientList)
            {
                clientList.Remove(client);
            }
        }

        public void SendResponse(Client client,RequestCode requestCode,string data)
        {

        }
    }
}
