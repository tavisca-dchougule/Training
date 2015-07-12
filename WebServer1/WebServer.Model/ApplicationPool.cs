using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Model
{
    class ApplicationPool
    {
        private Socket _clientSocket;
        private string _contentPath;
        RegistryKey registryKey = Registry.ClassesRoot;

        private Encoding _charEncoder = Encoding.UTF8;
        public FileHandler FileHandler;
        string _requestedFile;
        public ApplicationPool(Socket clientSocket,string contentPath,string requestedFile)
        {
            _requestedFile = requestedFile;
            _clientSocket = clientSocket;
            _contentPath = contentPath;
            FileHandler = new FileHandler(_contentPath);
        }
        public void ResponseHtml()
        {
            Console.WriteLine("in html");
            RequestUrl(_requestedFile);
        }
        public void ResponseJs()
        {
            Console.WriteLine("in js");
            RequestUrl(_requestedFile);
        }
        public void ResponseCss()
        {
            Console.WriteLine("in css");
            RequestUrl(_requestedFile);
        }
        public void DefaultHandler()
        {
            Console.WriteLine("in default");
            RequestUrl(_requestedFile);
        }
        public void RequestUrl(string requestedFile)
        {
            int dotIndex = requestedFile.LastIndexOf('.') + 1;
            if (dotIndex > 0)
            {
                if (FileHandler.DoesFileExists(requestedFile))    //If yes check existence of the file
                    SendResponse(_clientSocket, FileHandler.ReadFile(requestedFile), "200 Ok", GetTypeOfFile(registryKey, (_contentPath + requestedFile)));
                else
                    SendErrorResponce(_clientSocket);      // We don't support this extension.
            }
            else   //find default file as index .htm of index.html
            {
                if (FileHandler.DoesFileExists("\\index.htm"))
                    SendResponse(_clientSocket, FileHandler.ReadFile("\\index.htm"), "200 Ok", "text/html");
                else if (FileHandler.DoesFileExists("\\index.html"))
                    SendResponse(_clientSocket, FileHandler.ReadFile("\\index.html"), "200 Ok", "text/html");
                else
                    SendErrorResponce(_clientSocket);
            }
        }

        private string GetTypeOfFile(RegistryKey registryKey, string fileName)
        {
            RegistryKey fileClass = registryKey.OpenSubKey(Path.GetExtension(fileName));
            return fileClass.GetValue("Content Type").ToString();
        }

        private void SendErrorResponce(Socket clientSocket)
        {
            SendResponse(clientSocket, null, "404 Not Found", "text/html");
        }


        private void SendResponse(Socket clientSocket, byte[] byteContent, string responseCode, string contentType)
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
