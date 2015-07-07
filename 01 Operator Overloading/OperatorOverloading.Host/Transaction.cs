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
           // Console.ReadKey();
            Money money1 = new Money();
            Money money2 = new Money();
            Money money3 = new Money();



            Console.WriteLine("Enter 1st Currency:");
                money1.Currency = Console.ReadLine();


                while (true)
                {

                    Console.WriteLine("Enter amount for that Currency.");
                    try
                    {

                        string input = Console.ReadLine();
                        money1.Amount = double.Parse(input);
                        if (money1.Amount < 0)
                        {
                            Console.WriteLine("Enter valid Amount,  Enter again:");
                            continue;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid Amount, Enter again: ");
                        continue;
                    }
                    break;
                }

              
             Console.WriteLine();
            
            Console.WriteLine("Enter 2nd Currency.");
            money2.Currency = Console.ReadLine();

            while (true)
            {

                Console.WriteLine("Enter amount for that Currency.");
                try
                {

                    string input = Console.ReadLine();
                    money2.Amount = double.Parse(input);
                    if (money1.Amount < 0)
                    {
                        Console.WriteLine("Enter valid Amount,  Enter again:");
                        continue;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Amount,  Enter again:");
                    continue;
                }
                break;
            }

            try
            {
                money3 = money1 + money2;
            }
            catch (InvalidCurrencyException exception)
            {
                Console.WriteLine(""+exception.Message);
                Console.ReadKey();
                return;
            }
            catch (OutOfRangeException exception)
            {
                Console.WriteLine("" + exception.Message);
                Console.ReadKey();
                return;
            }

            Console.WriteLine();

            Console.WriteLine("Amount1: "+money1.Amount +"  Currency1: "+ money1.Currency);
            Console.WriteLine("Amount2: " + money2.Amount + "  Currency2: " + money2.Currency);
            Console.WriteLine("After Addition:");
            Console.WriteLine("Amount3: " + money3.Amount + "  Currency3: " + money3.Currency);
            
            Console.ReadKey();
        }
    }
}

