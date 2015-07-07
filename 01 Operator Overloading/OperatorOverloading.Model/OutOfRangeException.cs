using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Model
{
    public class OutOfRangeException : Exception
    {
        private string message;
        /* this is user defined exception
         * when object of this exception is created, "Out of Range Exception." message stored in message variable. */
        public OutOfRangeException()
        {
            this.message = "Out of Range Exception."; 
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
