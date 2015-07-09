using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Model;

namespace OperatorOverloading.dbl
{
    /*this class will parse the json format string received from WebFetch class.
     this class implements IParser interface which has ParseFile method*/
    class ParseJSON : IParser
    {
        //exchangeRates is a dictonary object which will consist of currency as a key, and conversion rate as value.
        Dictionary<string, double> exchangeRates = new Dictionary<string, double>();
        public string Source
        {
            get;
            set;
        }

        public Dictionary<string, double> ParseFile(string builder)
        {
            if (builder == null)
            {
                throw new ArgumentException(Resources.InvalidArgument);
            }
            string data = builder;
            string[] dataSplit = data.Split('{');
            string tempData = dataSplit[1];
            string[] tempSplit1 = tempData.Split(',');
            tempSplit1 = tempSplit1[tempSplit1.Length - 2].Split(':');
            Source = tempSplit1[1];

            data = dataSplit[2];
            data = data.Replace('}', ' ');
            data = data.Trim();
            dataSplit = data.Split(',');
            for (int i = 0; i < dataSplit.Length; i++)
            {
                dataSplit[i] = dataSplit[i].Replace("USD", "");
                tempSplit1 = dataSplit[i].Split(':');
                data = tempSplit1[0];
                double value = 0.0;
                tempSplit1[1] = tempSplit1[1].Trim();
                if (double.TryParse(tempSplit1[1], out value) == false)
                    throw new Exception(Resources.InvalidNumber);
                data = data.Trim();
                data = data.Remove(data.Length - 1, 1);
                data = data.Remove(0, 1);

                exchangeRates.Add(data, value);
            }
            exchangeRates.Add("USD", 1.0);
            return exchangeRates;//here we return exchangeRates.
        }
    }
}
