using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Interfaces;
using System.Configuration;
using ClassLibrary1;

namespace OperatorOverloading.dbl
{
    public class ExchangeRateProvider : IExchangeRateProvider
        {
            public double GetExchangeRate(string fromCurrency, string toCurrency)
            {
                if (fromCurrency == null || toCurrency == null)
                {
                    throw new ArgumentException(Resources.InvalidArgument);
                }
            
                string currency1 = fromCurrency.ToUpper(); //here case is handeled by converting string to upper case, as currencies are stored in uppercase in dictonary.
                string currency2 = toCurrency.ToUpper();
                ParseJSON parser = null;
               
                try
                {
                     parser = new ParseJSON();
                     
                }
                catch (Exception e)
                {
                    throw e;
                }
                string webData = "";
                Dictionary<string, double> conversionRates = null;
                
                try
                {
                    
                    WebClient client = new WebClient();
                    
                    string url = ConfigurationManager.AppSettings["CurrencyURL"];
                 
                    //webData will consist of the fetched data from webpage.
                    webData = client.DownloadString(url);

                    
                    //conversionRates is a dictonary object which contains currency as key and conversion rates as value.
                    conversionRates = parser.ParseFile(webData);
                    
                    
                }
                catch (Exception e)
                {
                    throw e;
                }
                if (currency1.ToUpper().Equals(parser.Source) == false)
                    throw new Exception(Resources.InvalidCurrency);
                double conversionRate = 0.0;
                

                if (conversionRates.TryGetValue(currency2, out conversionRate) == false)
                {     
                    throw new Exception(Resources.InvalidCurrency);
                }
              
                return conversionRate;   
            }
        }
    
}
