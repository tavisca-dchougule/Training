using System;
using System.Collections.Generic;
using System.Configuration;
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
       // private int _timeout = 120;
        private Encoding _charEncoder = Encoding.UTF32;
        private Socket _serverSocket;
        private static List<Socket> _socketList = new List<Socket>();
        // Directory to host our contents
        private string _contentPath;

        public static void AddSocket(Socket socket)
        {
            _socketList.Add(socket);
        }
        public static void RemoveSocket(Socket socket)
        {
            _socketList.Remove(socket);
        }
        public static bool IsSocketListFull()
        {
            int requestLength = int.Parse(ConfigurationManager.AppSettings["MaxRequestLength"]);
            if (_socketList.Count() >= requestLength)
                return true;
            else
                return false;
        }
       


        public void Start(int port, string contentPath)
        {
            if (contentPath == null)
                throw new ArgumentException(Messages.InvalidArgument);
            try
            {
                _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
                _serverSocket.Listen(int.MaxValue);    //no of request in queue
                //_serverSocket.ReceiveTimeout = _timeout;
                //_serverSocket.SendTimeout = _timeout;
                _contentPath = contentPath;
            }
            catch
            {
            }

            try
            {
                RequestListener requestListener = new RequestListener(_serverSocket, contentPath);
                requestListener.Listen();
               // Thread startListener = new Thread(new ThreadStart(requestListener.Listen));
                //startListener.Start();
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
