using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace OperatorOverloading.Model
{
     [Serializable()]
    public class OutOfRangeException : Exception
    {
        /* this is user defined exception*/
        
        public OutOfRangeException()
        {
           
        }
        protected OutOfRangeException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        : base(info, context) //serialization
        { 
        }
        
    }
}
