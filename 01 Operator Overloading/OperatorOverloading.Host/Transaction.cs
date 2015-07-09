using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Model;
using System.Xml.Serialization;
using System.IO;
using OperatorOverloading.dbl;

/* amar has told us to write a conversion code for conversion code from only USD to any other currency as only JSON file of USD to other currency is available.
 * but i have used some mathematical calculations to convert from any currency to any other currency using same json file*/

namespace OperatorOverloading.Host
{
    class Transaction
    {
        static void Main(string[] args)
        {
            CurrencyConverter converter = new CurrencyConverter();

            Money fromMoney = new Money();
            Money toMoney = new Money();
            Money convertedMoney = new Money();

            while (true)// condition to check currency is not empty
            {
                Console.WriteLine("Enter from which Currency you want to convert: ");
                try
                {
                    fromMoney.Currency = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                break;
            }

            while (true) //this while keep on taking the input unless you enter valid amount.
            {
                Console.WriteLine("Enter your amount to convert: ");

                string input = Console.ReadLine();
                double temp = 0.0;
                if (double.TryParse(input, out temp))
                {
                    fromMoney.Amount = temp;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Amount, Enter again: ");
                    continue;
                }

            }

            Console.WriteLine();

            while (true)// condition to check currency is not empty
            {
                Console.WriteLine("Enter to which Currency you want to convert: ");
                try
                {
                    toMoney.Currency = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                break;
            }

            try
            {
                convertedMoney = converter.ConvertCurrency(fromMoney, toMoney);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Converted amount is: {0} Currency: {1}", convertedMoney.Amount, convertedMoney.Currency);
            Console.ReadKey();

        }
        
    }
}

