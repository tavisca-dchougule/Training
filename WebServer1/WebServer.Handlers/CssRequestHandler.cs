using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebServer.Interfaces;

namespace WebServer.Handlers
{
    public class CssRequestHandler : IRequestHandler
    {
        private Socket _clientSocket;
        private string _contentPath;
        private RegistryKey _registryKey = Registry.ClassesRoot;
        private Encoding _charEncoder = Encoding.UTF8;
        private string _requestedFile;

        public CssRequestHandler(Socket clientSocket, string contentPath, string requestedFile)
        {
            _requestedFile = requestedFile;
            _clientSocket = clientSocket;
            _contentPath = contentPath;
        }

        public void SendResponse()
        {
            if (_clientSocket == null || _contentPath == null || _requestedFile == null)
                throw new NullReferenceException(Messages.NullReference);
           
            int dotIndex = _requestedFile.LastIndexOf('.') + 1;
            if (dotIndex > 0)
            {
                if (File.Exists(_contentPath + _requestedFile))
                {
                    byte[] content = File.ReadAllBytes(_contentPath + _requestedFile);
                    SendResponse(_clientSocket, content, "200 Ok", GetTypeOfFile((_contentPath + _requestedFile)));   
                }
                else
                {
                    byte[] temp = new byte[0];
                    SendResponse(_clientSocket, temp, "404 Not Found", "text/html");    // We don't support this extension.
                }
            }
            else   //find default file as index .htm of index.html
            {
                if (File.Exists(_contentPath + "\\index.htm"))
                {
                    byte[] content = File.ReadAllBytes(_contentPath + "\\index.htm");       
                    SendResponse(_clientSocket, content, "200 Ok", "text/html");
                }
                else if (File.Exists(_contentPath + "\\index.html"))
                {
                    byte[] content = File.ReadAllBytes(_contentPath + "\\index.html");
                    SendResponse(_clientSocket, content, "200 Ok", "text/html");
                }

                else
                {
                    byte[] temp = new byte[0];
                    SendResponse(_clientSocket, temp, "404 Not Found", "text/html");
                }
            }
        }

        private string GetTypeOfFile( string fileName)
        {
            RegistryKey fileClass = _registryKey.OpenSubKey(Path.GetExtension(fileName));
            return fileClass.GetValue("Content Type").ToString();
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
