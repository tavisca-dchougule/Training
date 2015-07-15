using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.dbl;

namespace OperatorOverloading.Model
{
    public class Money
    {
        private string _currency;
        public double Amount
        {
            get;
            set;
        }
        public string Currency
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value) || (value).Length != 3)
                {
                    throw new Exception(Messages.InvalidCurrency);
                }
                _currency = value;
            }
            get
            {
                return _currency;
            }
        }
        public Money Convert(String toCurrency)
        {
          //  Console.WriteLine(""+toCurrency+"      "+this.Currency);
            
            ExchangeRateProvider converter = new ExchangeRateProvider();
            double exchangeRate=0.0;
            try
            {
                exchangeRate = converter.GetExchangeRate(this.Currency, toCurrency);
            }
            catch (Exception e)
            {
                throw e;
            }
            Money convertedMoney = new Money();
            convertedMoney.Currency = toCurrency;
            convertedMoney.Amount = this.Amount * exchangeRate;
            return convertedMoney;

            
        }
        public static Money operator +(Money money1, Money money2) //this is operator overloaded function
        {
            if (money1 == null || money2 == null)
            {
                 throw new ArgumentException(Messages.InvalidArgument);
            }
            Money money3 = new Money();
           

            if (string.Equals(money1.Currency, money2.Currency, StringComparison.OrdinalIgnoreCase)) //here we r checking whether the currencies of both money is same or not.. if not throw InvalidCurrencyException exception 
            {
                money3.Amount = money1.Amount + money2.Amount;
                if(double.IsInfinity(money3.Amount))// here we r checking whether range of double is exceeded or not....if yes then throw out of range exception
                {
                    throw new OverflowException();
                }
               
            }
            else
            {
                throw new CurrencyMismatchException();
             
            }
            money3.Currency = money1.Currency;
            return money3;
        }
        public override  string ToString()
        {
            StringBuilder display=new StringBuilder();
            display.Append("Amount1: "+this.Amount+"  Currency1: "+ this.Currency);

            return display.ToString();  
        }
    }
}
