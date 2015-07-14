using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Model;
using System.Configuration;

namespace WebServer.Host
{
    class Host
    {
        static void Main(string[] args)
        {
            WebServer1 webServer = new WebServer1();
            try
            {
                string path = ConfigurationManager.AppSettings["path"];
                webServer.Start(8080, path);
            }
            catch
            { }
            Console.ReadKey();
        }
    }
}
