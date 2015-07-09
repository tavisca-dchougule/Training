using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Model;

namespace OperatorOverloading.dbl
{
    public class CurrencyConverter : ICurrencyConverter
        {
            public Money ConvertCurrency(Money fromCurrency, Money toCurrency)
            {
                if (fromCurrency == null || toCurrency == null)
                {
                    throw new ArgumentException(Resources.InvalidArgument);
                }

                string currency1 = fromCurrency.Currency.ToUpper(); //here case is handeled by converting string to upper case, as currencies are stored in uppercase in dictonary.
                string currency2 = toCurrency.Currency.ToUpper();
                WebFetch fetch=null;
                ParseJSON parser = null;
                try
                {
                     fetch = new WebFetch();
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
                    //webData will consist of the fetched data from webpage.
                    webData = fetch.Fetch(Resources.CurrencyURL);
                    //conversionRates is a dictonary object which contains currency as key and conversion rates as value.
                    conversionRates = parser.ParseFile(webData);
                }
                catch (Exception e)
                {
                    throw e;
                }
                double conversionRate1 = 0.0;
                double conversionRate2 = 0.0;

                if (conversionRates.TryGetValue(currency1, out conversionRate1) == false)
                {
                    
                    throw new Exception(Resources.InvalidCurrency);
                }
                if (conversionRates.TryGetValue(currency2, out conversionRate2) == false)
                {
                    
                    throw new Exception(Resources.InvalidCurrency);
                }
                /*here is the logic for the inter conversion of currency.
                i.e. i can convert from any currency to any other currency*/
                double conversionRate = (conversionRate2 / conversionRate1);

                Money convertedCurrency = new Money();

                convertedCurrency.Amount = (fromCurrency.Amount * conversionRate);
                convertedCurrency.Currency = toCurrency.Currency;
                return convertedCurrency;
                //here convertedCurrency is a Money object which is returned. and it will consist answer i.e. converted rate.
            }
        }
    
}
