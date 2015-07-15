using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using OperatorOverloading.Model;

namespace OperatorOverloading.Interfaces
{
    /*ICurrencyConverter is a interface which consist of ConvertCurrency method.
     * this interface is implemented by the CurrencyConverter class.*/
    public interface IExchangeRateProvider
    {
        double GetExchangeRate(string money1, string money2);
    }
}
