using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using OperatorOverloading.Model;
namespace OperatorOverloading.dbl
{
    /* this class fetches the json file content in a string and return it.
     * this process will take time as it will have to wait for the completion of http request and http response .
     * alternative to this is we can save content to file periodically. we can create a fetch thread which will fetch the webpage periodically and stores in file.*/
    class WebFetch
    {
        public string Fetch(string url)
        {
            if (url == null)
            {
                throw new ArgumentException(Resources.InvalidArgument);
            }

            StringBuilder sb = new StringBuilder();
            byte[] buf = new byte[8192];
            HttpWebRequest request=null;
            Stream resStream=null;
            HttpWebResponse response = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                response = (HttpWebResponse)request.GetResponse();
                resStream = response.GetResponseStream();
            }
            catch (Exception e)
            {
                throw e;
            }

            string tempString = null;
            int count = 0;

            do
            {
                count = resStream.Read(buf, 0, buf.Length);
                if (count != 0)
                {
                    tempString = Encoding.ASCII.GetString(buf, 0, count);
                    sb.Append(tempString);
                }
            }
            while (count > 0); 
            return sb.ToString();
        }
    }
}
