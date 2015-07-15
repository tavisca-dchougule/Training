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
                string sourcePath = ConfigurationManager.AppSettings["Path"];
                int port = int.Parse(ConfigurationManager.AppSettings["PortNumber"]);
                webServer.Start(port, sourcePath);
            }
            catch(Exception e)
            {
                throw e;
                //Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
