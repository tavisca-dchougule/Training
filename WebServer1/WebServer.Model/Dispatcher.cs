using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebServer.Model
{
    class Dispatcher
    {
        private Socket _clientSocket;
        private Encoding _charEncoder = Encoding.UTF8;
        public string HttpMethod;
        public string HttpUrl;
        public string HttpProtocolVersion;
     
        private string _contentPath;

        
        public Dispatcher(Socket clientSocket,string contentPath)
        {
            _clientSocket=clientSocket;
            _contentPath = contentPath;
        }

        public void Start()
        {
            if (_clientSocket == null || _contentPath == null )
                throw new NullReferenceException(Messages.NullReference);
             
                 try
                 {
                     this.DecodeRequest();
                     ApplicationPool responseHandler = new ApplicationPool(_clientSocket, _contentPath, HttpUrl);
                     responseHandler.Start();
                   //  Thread startApplicationPool = new Thread(new ThreadStart(responseHandler.Start));
                    // startApplicationPool.Start();
                 }
                 catch
                 {   
                 }
        }
        
        private void DecodeRequest()
        {
            var receivedBufferlen = 0;
            var buffer = new byte[10240];
           
            try
            {
                receivedBufferlen = _clientSocket.Receive(buffer);
            }
            catch (Exception e)
            {
                throw e;
            }
           string requestData= _charEncoder.GetString(buffer, 0, receivedBufferlen);
 
            try
            {
                string[] tokens = requestData.Split(' ');
                
                    tokens[1] = tokens[1].Replace("/", "\\");
                    HttpMethod = tokens[0].ToUpper();
                    HttpUrl = tokens[1];
                
                    HttpProtocolVersion = tokens[2];
                
            }
            catch (Exception e)
            {
                throw e;
            }
          
        }
        
    }
}
