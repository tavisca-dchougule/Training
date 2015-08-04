using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMS.ErrorSpace
{
    [Serializable()]
    public class BaseApplicationException : Exception
    {
        /* this is user defined exception*/
        public BaseApplicationException()
        {

        }
        protected BaseApplicationException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)  //serialization
        {
        }
    }
}
