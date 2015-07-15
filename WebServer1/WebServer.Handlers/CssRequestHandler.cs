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
                    //If yes check existence of the file
                    byte[] content = File.ReadAllBytes(_contentPath + _requestedFile);
                    SendResponse( content, "200 Ok", GetTypeOfFile());


                }
                else
                {
                    byte[] temp = new byte[0];

                    SendResponse( temp, "404 Not Found", "text/html");    // We don't support this extension.

                }
            }
            else   //find default file as index .htm of index.html
            {

                if (File.Exists(_contentPath + "\\index.htm"))
                {
                    byte[] content = File.ReadAllBytes(_contentPath + "\\index.htm");

                    SendResponse( content, "200 Ok", "text/html");


                }
                else if (File.Exists(_contentPath + "\\index.html"))
                {
                    byte[] content = File.ReadAllBytes(_contentPath + "\\index.html");

                    SendResponse( content, "200 Ok", "text/html");
                }

                else
                {
                    byte[] temp = new byte[0];

                    SendResponse(temp, "404 Not Found", "text/html");
                }


            }
        }

        private string GetTypeOfFile()
        {
            RegistryKey fileClass = _registryKey.OpenSubKey(Path.GetExtension(_contentPath+_requestedFile));
            return fileClass.GetValue("Content Type").ToString();
        }

        private void SendResponse( byte[] byteContent, string responseCode, string contentType)
        {
            try
            {

                byte[] byteHeader = CreateHeader(responseCode, byteContent.Length, contentType);
                _clientSocket.Send(byteHeader);
                _clientSocket.Send(byteContent);

                _clientSocket.Close();
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
