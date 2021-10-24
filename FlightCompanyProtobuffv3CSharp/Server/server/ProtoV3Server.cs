using Networking;
using Server.server;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server.server
{
    public class ProtoV3Server : ConcurrentServer
    {
        private IServices server;
        private ProtoWorker worker;

        public ProtoV3Server(string host, int port, IServices server)
            : base(host, port)
        {
            this.server = server;
            Console.WriteLine("ProtoV3Server...");
        }

        protected override Thread createWorker(TcpClient client)
        {
            worker = new ProtoWorker(server, client);
            return new Thread(new ThreadStart(worker.Run));
        }
    }
}
