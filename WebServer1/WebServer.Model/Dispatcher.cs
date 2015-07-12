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
        public string contentType;
        private string _fileExtention;
        RegistryKey registryKey = Registry.ClassesRoot;
        private string _contentPath;

        
        public Dispatcher(Socket clientSocket,string contentPath)
        {
            _clientSocket=clientSocket;
            _contentPath = contentPath;
        }

        public void Start()
        {
             DecodeRequest(_clientSocket);
             ResourceManager myManager = new ResourceManager(typeof(ApplicationPoolMapping));
             string handler = myManager.GetString(_fileExtention);
             if (handler == null)
                 handler = "DefaultHandler";
            // Console.WriteLine(handler);
             
                 ApplicationPool responseHandler = new ApplicationPool(_clientSocket, _contentPath, HttpUrl);
                Type thisType = responseHandler.GetType();
             MethodInfo theMethod = thisType.GetMethod(handler);
             ThreadStart worker = delegate
             {
                 var result = theMethod.Invoke(responseHandler, null);
             };
             new Thread(worker).Start();
             

             

             
        }
        
        private void DecodeRequest(Socket clientSocket)
        {
            var receivedBufferlen = 0;
            var buffer = new byte[10240];
            try
            {
                receivedBufferlen = clientSocket.Receive(buffer);
            }
            catch (Exception)
            {
                //Console.WriteLine("buffer full");
                Console.ReadLine();
            }
           string requestData= _charEncoder.GetString(buffer, 0, receivedBufferlen);
            try
            {
                string[] tokens = requestData.Split(' ');

                tokens[1] = tokens[1].Replace("/", "\\");
                HttpMethod = tokens[0].ToUpper();
                HttpUrl = tokens[1];
                HttpProtocolVersion = tokens[2];

                Console.WriteLine("HttpMethod : " + HttpMethod);
                Console.WriteLine("HttpUrl : " + HttpUrl);
                Console.WriteLine("HttpProtocolVersion : " + HttpProtocolVersion);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.InnerException.Message);
                Console.WriteLine("Bad Request");
            }
            _fileExtention = Path.GetExtension(_contentPath + HttpUrl);
            
            RegistryKey fileClass = null;
          
                fileClass = registryKey.OpenSubKey(_fileExtention);
            
            if (fileClass == null)
                Console.WriteLine("hii");
            try
            {
                contentType = fileClass.GetValue("Content Type").ToString();
            }
            catch (Exception e)
            {
            }
            _fileExtention = _fileExtention.Remove(0, 1);
        }
        
    }
}
