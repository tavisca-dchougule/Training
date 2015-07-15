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
        //private int _timeout;
        private string _contentPath;
        private Encoding _charEncoder = Encoding.UTF8;
        private bool _running = false;

        public RequestListener(Socket serverSocket, String contentPath)
        {
            _serverSocket = serverSocket;
          //  _timeout = 120;
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
                    if (WebServer1.IsSocketListFull() == true)
                    {
                        byte[] temp = new byte[0];
                        this.SendResponse(clientSocket, temp, "503 Service Unavailable", "text/html");
                    }
                    WebServer1.AddSocket(clientSocket);
                    Dispatcher dispatcher = new Dispatcher(clientSocket,_contentPath);
                    Thread startDispatcher = new Thread(new ThreadStart(dispatcher.Start));
                    startDispatcher.Start();
                    
                }
                catch
                {
                   
                }
            }
        }

      
        public void StopListener()
        {
            _running = false;
        }

        private void SendResponse(Socket clientSocket,byte[] byteContent, string responseCode, string contentType)
        {
            try
            {
                byte[] byteHeader = CreateHeader(responseCode, byteContent.Length, contentType);
                clientSocket.Send(byteHeader);
                clientSocket.Send(byteContent);
                clientSocket.Close();
            }
            catch
            {
            }
        }

        private byte[] CreateHeader(string responseCode, int contentLength, string contentType)
        {
            return _charEncoder.GetBytes("HTTP/1.1 " + responseCode + "\r\n"
                                  + "Server: Simple Web Server\r\n"
                                  + "Content-Length: " + contentLength + "\r\n"
                                  + "Connection: close\r\n"
                                  + "Content-Type: " + contentType + "\r\n\r\n");
        }
       
    }
}
