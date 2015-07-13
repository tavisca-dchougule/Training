using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebServer.Model
{
    public class WebServer1
    {
     
        private static List<Socket> _clientList = new List<Socket>();
        private int _timeout = 120;
        private Encoding _charEncoder = Encoding.UTF8;
        private Socket _serverSocket;

        // Directory to host our contents
        private string _contentPath;

        public void Start(int port, string contentPath)
        {
            if (contentPath == null)
                throw new ArgumentException(Messages.InvalidArgument);
            try
            {
               // InitializeSocket(port, contentPath);
                _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
                _serverSocket.Listen(int.MaxValue);    //no of request in queue
                _serverSocket.ReceiveTimeout = _timeout;
                _serverSocket.SendTimeout = _timeout;
                _contentPath = contentPath;
            }
            catch
            {
            }

            try
            {
                RequestListener requestListener = new RequestListener(_serverSocket, contentPath);
                Thread startListener = new Thread(new ThreadStart(requestListener.Listen));
                startListener.Start();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Stop()
        {
           
            try
            {
                _serverSocket.Close();
            }
            catch
            {
            }
            _serverSocket = null;
        }
    }
}
