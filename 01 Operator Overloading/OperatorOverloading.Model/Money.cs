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
        public static Money operator +(Money Money1, Money Money2)
        {
            Money Money3 = new Money();
           
            if ((Money1.Currency).Equals(Money2.Currency))
            {
                Money3.Amount = Money1.Amount + Money2.Amount;
                if(double.IsInfinity(Money3.Amount))
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
