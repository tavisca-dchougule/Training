using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebServer.Model
{
    class RequestListener
    {
        private Socket _serverSocket;
        private int _timeout;
        private string _contentPath;
        private Encoding _charEncoder = Encoding.UTF8;
        private bool _running = false;

        public RequestListener(Socket serverSocket, String contentPath)
        {
            _serverSocket = serverSocket;
            _timeout = 120;
            _contentPath = contentPath;
            _running = true;
        }

        public void Listen()
        {
            if (_serverSocket == null || _contentPath == null)
                throw new NullReferenceException(Messages.NullReference);
            while (_running)
            {
                Socket clientSocket = null;
                try
                {
                  
                    clientSocket = _serverSocket.Accept();
                    
                    clientSocket.ReceiveTimeout = _timeout;
                    clientSocket.SendTimeout = _timeout; 

                    Dispatcher dispatcher = new Dispatcher(clientSocket,_contentPath);
                    Thread startDispatcher = new Thread(new ThreadStart(dispatcher.Start));
                    startDispatcher.Start();
                    
                }
                catch
                {
                    if (clientSocket != null)
                        clientSocket.Close();
                }
            }
        }

      
        public void StopListener()
        {
            _running = false;
        }

       
    }
}
