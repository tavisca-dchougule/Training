using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Model;

namespace OperatorOverloading.Host
{
    class Transaction
    {
        static void Main(string[] args)
        {
            Money money1 = new Money();
            Money money2 = new Money();
            Money money3 = new Money();

            
           
            while (true) // condition to check currency is not empty
            {
                Console.WriteLine("Enter 1st Currency:");
                money1.Currency = Console.ReadLine();
                if (money1.Currency.Equals(""))
                {
                    Console.WriteLine("Invalid Currency.");
                    continue;
                }
                else
                    break;

            }


                while (true) //this while keep on taking the input unless you enter valid amount.
                {
                    Console.WriteLine("Enter amount for that Currency.");
                    
                        string input = Console.ReadLine();
                        double temp = 0.0;
                        if (Double.TryParse(input, out temp))
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
                 money2.Currency = Console.ReadLine();
                 if (money2.Currency.Equals(""))
                 {
                     Console.WriteLine("Invalid Currency.");
                     continue;
                 }
                 else
                     break;

             }

            
            while (true) //this while keep on taking the input unless you enter valid amount.
            {
                Console.WriteLine("Enter amount for that Currency.");

                string input = Console.ReadLine();
                double temp = 0.0;
                if (Double.TryParse(input, out temp))
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
            /* this catch handles the invalid currency exception which is defined by the user.
             * out of range exception occurs when the currencies of both the adding money is different*/
            catch (InvalidCurrencyException exception) //this catch handles the Invalid Currency Exception which is defined by the user.
            {
                Console.WriteLine("" + exception.Message);
                Console.ReadKey();
                return;
            }
            /* this catch handles the Out of range exception which is defined by the user.
             * out of range exception occurs when range of double is exceeded after addition*/
            catch (OutOfRangeException exception)
            {
                Console.WriteLine("" + exception.Message);
                Console.ReadKey();
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.StackTrace);
            }

            Console.WriteLine();
            Console.WriteLine("Amount1: {0}  Currency1: {1}",money1.Amount, money1.Currency);
            Console.WriteLine("Amount2: {0}  Currency2: {1}", money2.Amount, money2.Currency);
            Console.WriteLine("After Addition:");
            Console.WriteLine("Amount3: {0}  Currency3: {1}", money3.Amount, money3.Currency);
            
            Console.ReadKey();
        }
    }
}

