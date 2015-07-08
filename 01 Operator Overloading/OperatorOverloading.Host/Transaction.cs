using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Model;
using System.Xml.Serialization;
using System.IO;


namespace OperatorOverloading.Host
{
    class Transaction
    {
        static void Main(string[] args)
        {
            Money money1 = new Money();
            Money money2 = new Money();
            Money money3 = new Money();

            /*here seperate loop s needed to check currency and amount
         * bcoz itz very complicated to impliment it in single loop and i'll be very hard to understand*/
        

             while (true)// condition to check currency is not empty
             {
                 Console.WriteLine("Enter 1st Currency.");
                 try
                 {
                    money1.Currency = Console.ReadLine();
                 }
                 catch(Exception e)
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

            Console.WriteLine();

             while (true)// condition to check currency is not empty
             {
                 Console.WriteLine("Enter 2nd Currency.");
                 try
                 {
                     money2.Currency = Console.ReadLine();
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
                    money2.Amount = temp;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Amount, Enter again: ");
                    continue;
                }
                   
            }

            try
            {
                money3 = money1 + money2;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }

            Console.WriteLine();
            Console.WriteLine(money1.ToString());
            Console.WriteLine(money2.ToString());
            Console.WriteLine("After Addition:");
            Console.WriteLine(money3.ToString());
            
            Console.ReadKey();
        }
    }
}

