using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMS.ErrorSpace
{
    [Serializable()]
    public class LoginFailedException : Exception
    {

        /* this is user defined exception*/
        public LoginFailedException()
        {

        }
        protected LoginFailedException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)  //serialization
        {
        }
    }
}
