using System.Net.Sockets;
using System.Threading;

namespace Server.server
{
    public abstract class ConcurrentServer : AbstractServer
    {
        protected ConcurrentServer(string host, int port) : base(host, port)
        {

        }

        public override void processRequest(TcpClient client)
        {

            Thread t = createWorker(client);
            t.Start();

        }

        protected abstract Thread createWorker(TcpClient client);
    }
}