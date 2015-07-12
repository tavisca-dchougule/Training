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
            _timeout = 5;
            _contentPath = contentPath;
            _running = true;
        }

        public void Listen()
        {
            while (_running)
            {
                Socket clientSocket = null;
                try
                {
                    // Create new thread to handle the request and continue to listen the socket.
                    Console.WriteLine("Wating for connection.");
                    clientSocket = _serverSocket.Accept();
                    Console.WriteLine("Client has been accepted!");
                   // Console.WriteLine(clientSocket.);
                    
                    clientSocket.ReceiveTimeout = _timeout;
                    clientSocket.SendTimeout = _timeout;
                   
                    

                    Dispatcher dispatcher = new Dispatcher(clientSocket,_contentPath);
                    Thread startDispatcher = new Thread(new ThreadStart(dispatcher.Start));
                    startDispatcher.Start();
                    
                }
                catch
                {
                    
                    Console.WriteLine("Error in accepting client request");
                    Console.ReadLine();
                    if (clientSocket != null)
                        clientSocket.Close();
                }
            }
        }

       /* private void HandleTheRequest(Socket clientSocket)
        {
            var requestParser = new RequestParser();
            string requestString = DecodeRequest(clientSocket);
            Console.WriteLine(requestString);
            requestParser.Parser(requestString);

            if (requestParser.HttpMethod.Equals("get", StringComparison.InvariantCultureIgnoreCase))
            {
                var createResponse = new CreateResponse(clientSocket, _contentPath);
                createResponse.RequestUrl(requestParser.HttpUrl);
            }
            else
            {
                Console.WriteLine("unemplimented mothode");
                Console.ReadLine();
            }
            StopClientSocket(clientSocket);
        }
        */
        public void StopListener()
        {
            _running = false;
        }

       
    }
}
