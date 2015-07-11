using OperatorOverloading.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Host1
{
    class Program
    {
        static void Main(string[] args)
        {
            Money money1 = new Money();
          
            while (true)// condition to check currency is not empty
            {
                Console.WriteLine("Enter 1st Currency.");
                try
                {
                    money1.Currency = Console.ReadLine();
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
                Console.WriteLine("Enter amount for that Currency.");

                string input = Console.ReadLine();
                double temp = 0.0;
                if (double.TryParse(input, out temp))
                {
                    money1.Amount = temp;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Amount, Enter again: ");
                    continue;
                }

            }
            
            Console.WriteLine("Enter currency to which you want to convert: ");
            string toCurrency = Console.ReadLine();

            Money money2 = new Money();
            try
            {
                money2 = money1.Convert(toCurrency);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }

            Console.WriteLine();
    
            Console.WriteLine("Converted Amount:");
            Console.WriteLine(money2);

            Console.ReadKey();
        }
    }
}
