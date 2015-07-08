using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Model
{
    public class OutOfRangeException : Exception
    {
        private string _message;
        /* this is user defined exception
         * when object of this exception is created, "Out of Range Exception." message stored in message variable. */
        public OutOfRangeException()
        {
            _message = "Out of Range Exception."; 
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
