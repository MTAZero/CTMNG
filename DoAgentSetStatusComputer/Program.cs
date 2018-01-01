using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS;
using System.Net;
using System.Threading;

namespace DoAgentSetStatusComputer
{
    class Program
    {
        static void Main(string[] args)
        {
           while(true)
            {
                StatusComputerBUS.Instance.SetStatusComputer(Dns.GetHostName());
                Thread.Sleep(5000);
            }

        }
    }
}
