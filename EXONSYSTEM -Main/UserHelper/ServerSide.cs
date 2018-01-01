using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UserHelper
{
    public class ServerSide: IDisposable
    {
        public event SocketEventHandle ClientConnected;
        public event SocketEventHandle ClientDisConnected;
        public BindingList<SocketController> ClientList = new BindingList<SocketController>();
        Task MainTask;
        public ServerSide(int port = 3001)
        {
            MainTask = Task.Factory.StartNew(() =>
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, port);
                Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                newsock.Bind(ipep);
                newsock.Listen(Common.BACK_LOG);
                while (true)
                {
                    Socket client = newsock.Accept();
                    var clientWinSock = new SocketController(client);
                    clientWinSock.NoConnected += new SocketEventHandle(clientWinSock_NoConnected);
                    ClientList.Add(clientWinSock);
                    if (ClientConnected != null)
                        ClientConnected(this, clientWinSock);
                }
            });
        }
        public ServerSide(string ip = "127.0.0.1", int port = 3001)
        {
            MainTask = Task.Factory.StartNew(() =>
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), port);
                Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                newsock.Bind(ipep);
                newsock.Listen(Common.BACK_LOG);
                while (true)
                {
                    Socket client = newsock.Accept();
                    var clientWinSock = new SocketController(client);
                    clientWinSock.NoConnected += new SocketEventHandle(clientWinSock_NoConnected);
                    ClientList.Add(clientWinSock);
                    if (ClientConnected != null)
                        ClientConnected(this, clientWinSock);
                }
            });
        }
        static object objectSync = new object();
        void clientWinSock_NoConnected(object sender, object data)
        {
            lock (objectSync)
            {
                for (int i = ClientList.Count - 1; i >= 0; i--)
                {
                    if (sender == ClientList[i])
                        ClientList.RemoveAt(i);
                }
                if (ClientDisConnected != null)
                    ClientDisConnected(this, sender);
            }
        }
        public void Dispose()
        {
            foreach (var item in ClientList)
            {
                if (item != null)
                {
                    item.Dispose();
                }
            }
            MainTask.Dispose();
        }
    }
}
