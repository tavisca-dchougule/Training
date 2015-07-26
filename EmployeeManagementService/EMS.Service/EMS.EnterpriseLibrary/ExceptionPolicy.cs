using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Lib=Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace EMS.EnterpriseLibrary
{
    public class ExceptionPolicy
    {
        public static bool HandleException(string policy, Exception ex)
        {
            return Lib.ExceptionPolicy.HandleException(ex, policy);
        }
    }
}
