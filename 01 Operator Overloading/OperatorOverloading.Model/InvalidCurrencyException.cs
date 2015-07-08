using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Model
{
    [Serializable()]
   public class InvalidCurrencyException : Exception
    {
        private string _message;
        /* this is user defined exception
         * when object of this exception is created, "Currency of Both the Amount is Different." message stored in message variable. */
        public InvalidCurrencyException()
        {
             _message="Currency of Both the Amount is Different.";
        }
        public override string Message
        {
            get
            {
                return _message;
            }
           
        }
        
    }
}
