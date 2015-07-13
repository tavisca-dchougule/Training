using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Model;

namespace WebServer.Host
{
    class Host
    {
        static void Main(string[] args)
        {
            WebServer1 webServer = new WebServer1();
            try
            {
                webServer.Start(8080, @"D:\web source\startbootstrap-sb-admin-1.0.3");
            }
            catch
            { }
            Console.ReadKey();
        }
    }
}
