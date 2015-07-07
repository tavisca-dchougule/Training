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
