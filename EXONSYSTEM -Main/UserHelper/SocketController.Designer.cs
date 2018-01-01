using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserHelper
{
    public partial class SocketController
    {
        private readonly object objectSync = new object();
        NetworkStream netStream;
        public NetworkStream NetStream
        {
            get
            {
                if (netStream != null)
                {
                    return netStream;
                }
                else
                {
                    lock (objectSync)
                    {
                        if (netStream == null && socket != null && socket.Connected)
                        {
                            netStream = new NetworkStream(socket);
                            sReader = null;
                            sWriter = null;
                        }
                    }
                    return netStream;
                }

            }
        }
        StreamReader sReader;
        public StreamReader Reader
        {
            get
            {
                if (sReader != null)
                {
                    return sReader;
                }
                else
                {
                    lock (objectSync)
                    {
                        if (sReader == null)
                            sReader = new StreamReader(NetStream);
                    }
                    return sReader;
                }
            }
        }
        StreamWriter sWriter;
        public StreamWriter Writer
        {
            get
            {
                if (sWriter == null)
                {
                    lock (objectSync)
                    {
                        if (sWriter == null)
                            sWriter = new StreamWriter(NetStream);
                    }
                }
                return sWriter;
            }
        }
    }
}
