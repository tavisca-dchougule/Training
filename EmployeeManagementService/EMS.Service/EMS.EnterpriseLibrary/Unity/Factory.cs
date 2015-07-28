using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.EnterpriseLibrary.Unity
{
    public class Factory
    {
        public static IUnityContainer GetUnityConfiguration()
        {
            IUnityContainer container = new UnityContainer();
            UnityConfigurationSection section=null;
            try
            {
                 section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            }
            catch (Exception e)
            {
                var rethrow = ExceptionPolicy.HandleException("Policy1", e);
                if (rethrow) throw e;
                return null;
            }
            section.Configure(container);
            return container;
        }
    }
}
