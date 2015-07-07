using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Model
{
    public class Money
    {
        private double amount;
        private string currency;

        public double Amount
        {
            set
            {
                this.amount = value;
            }
            get
            {
                return this.amount;
            }
        }
        public string Currency
        {
            set
            {
                this.currency = value;
            }
            get
            {
                return this.currency;
            }
        }
        public static Money operator +(Money Money1, Money Money2) //this is operator overloaded function
        {
            Money Money3 = new Money();

            if ((Money1.Currency).Equals(Money2.Currency)) //here we r checking whether the currencies of both money is same or not.. if not throw InvalidCurrencyException exception 
            {
                Money3.Amount = Money1.Amount + Money2.Amount;
                if(double.IsInfinity(Money3.Amount))// here we r checking whether range of double is exceeded or not....if yes then throw out of range exception
                {
                    throw new OutOfRangeException();
                }
                Money3.Currency = Money1.Currency;

            }
            else
            {
                throw new InvalidCurrencyException();
            }
            return Money3;
        }
    }
}
