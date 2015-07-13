using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using WebServer.Interfaces;
using WebServer.Handlers;
using System.Configuration;

namespace WebServer.Model
{
    class ApplicationPool
    {
          private Socket _clientSocket;
          private string _contentPath;
          private Encoding _charEncoder = Encoding.UTF8;
          private  string _requestedFile;
          private string _fileExtension;

          public ApplicationPool(Socket clientSocket,string contentPath,string requestedFile)
          {
              _requestedFile = requestedFile;
              _clientSocket = clientSocket;
              _contentPath = contentPath;
          }
        private  string Map()
          {
              _fileExtension = Path.GetExtension(_contentPath + _requestedFile);
            
              try
              {
                  _fileExtension = _fileExtension.Remove(0, 1);
              }
              catch 
              {
                  _fileExtension = "";
              }
              string handler = ConfigurationManager.AppSettings[_fileExtension];

              if (handler == null)
              {
                  throw new Exception(Messages.InvalidRequest);
              }
              return handler;
          }
       private  IRequestHandler GetHandler()
        {
            
            IRequestHandler handler = null;
            string input = "";
           try
            {
                 input = Map();
            }
           catch (Exception e) { throw e; }
            switch(input)
            {
                case "ResponseHtml":
                case "ResponseHtm":
                    handler=new HttpRequestHandler(_clientSocket, _contentPath, _requestedFile);
                    break;
                case "ResponseCss":
                    handler = new CssRequestHandler(_clientSocket, _contentPath, _requestedFile);
                    break;
                case "ResponseJs":
                    handler = new JsRequestHandler(_clientSocket, _contentPath, _requestedFile);
                    break;
               
            }
            return handler;

        }
        public void Start()
        {
            if (_clientSocket == null || _contentPath == null || _requestedFile == null)
                throw new NullReferenceException(Messages.NullReference);
           
            try
            {
                IRequestHandler handler = GetHandler();
                if(handler!=null)
                handler.SendResponse();
            }
            catch 
            {
                _clientSocket.Close();
            }
        }
    }
}
