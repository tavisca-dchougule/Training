using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Model
{
    public class Money
    {
        private double _amount;
        private string _currency;
        public double Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
            }
            
        }
        public string Currency
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value) || (value).Length != 3)
                {
                    throw new Exception("Invalid Currency.");
                }
                _currency = value;
            }
            get
            {
                return _currency;
            }
        }
        public static Money operator +(Money Money1, Money Money2) //this is operator overloaded function
        {
            if (Money1 == null)
            {
                 throw new NullReferenceException("Money 1 objet is null");
            }
             if (Money2 == null)
            {
                throw new NullReferenceException("Money 2 objet is null");
            }
            Money Money3 = new Money();

            if (string.Equals(Money1.Currency, Money2.Currency, StringComparison.OrdinalIgnoreCase)) //here we r checking whether the currencies of both money is same or not.. if not throw InvalidCurrencyException exception 
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
                throw new CurrencyMismatchException();
            }
            return Money3;
        }
        public override  string ToString()
        {
            StringBuilder display=new StringBuilder();
            display.Append("Amount1: "+this.Amount+"  Currency1: "+ this.Currency);

            return display.ToString();  
        }
    }
}
