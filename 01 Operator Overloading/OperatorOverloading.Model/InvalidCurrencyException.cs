using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Model
{
   public class InvalidCurrencyException : Exception
    {
        private string message;
        public InvalidCurrencyException()
        {
            this.message = "Currency of Both the Amount is Different.";
        }

        public string Message
        {
            get
            {
                return this.message;
            }
        }
    }
}
