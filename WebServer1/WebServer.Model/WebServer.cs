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
      //  private static Dictionary<string, string> _applicationPoolMapping = new Dictionary<string, string>();
        private static List<Socket> _clientList = new List<Socket>();
        private bool _running = false;
        private int _timeout = 5;
        private Encoding _charEncoder = Encoding.UTF8;
        private Socket _serverSocket;

        // Directory to host our contents
        private string _contentPath;

        public string GetContentPath()
        {
            return _contentPath;
        }

       /* public static string GetApplicationPool(string requestType)
        {
            string method="";
            requestType = requestType.Remove(0,1);
            
            if (_applicationPoolMapping.TryGetValue(requestType, out method) == false)
                return "DefaultHandler";
            return method;
        }*/
        public void AddClient(Socket socket)
        {
            _clientList.Add(socket);
        }

        public void Start(int port, string contentPath)
        {
            /*while (true)
            {
                string name="";
                string value="";
                ResourceSet resourceSet = MyResourceClass.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
                foreach (DictionaryEntry entry in resourceSet)
                {
                    string resourceKey = entry.Key;
                    object resource = entry.Value;
                }
             
             //   _applicationPoolMapping.Add(ApplicationPoolMapping.
            }*/
            try
            {
               // InitializeSocket(port, contentPath);
                _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
                _serverSocket.Listen(int.MaxValue);    //no of request in queue
                _serverSocket.ReceiveTimeout = _timeout;
                _serverSocket.SendTimeout = _timeout;
                _running = true; //socket created
                _contentPath = contentPath;
            }
            catch
            {
                Console.WriteLine("Error in creating server socker");
                Console.ReadLine();

            }
            
                RequestListener requestListener = new RequestListener(_serverSocket, contentPath);
                Thread startListener = new Thread(new ThreadStart(requestListener.Listen));
                startListener.Start();
        }
        public void Stop()
        {
            _running = false;
            try
            {
                _serverSocket.Close();
            }
            catch
            {
                Console.WriteLine("Error in closing server or server already closed");
                Console.ReadLine();

            }
            _serverSocket = null;
        }
    }
}
