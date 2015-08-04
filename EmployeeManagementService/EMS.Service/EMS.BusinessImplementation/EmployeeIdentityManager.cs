using EMS.BDataContract;
using EMS.BusinessDataContract;
using EMS.BusinessInterface;
using EMS.BusinessInterface.DBHandler;
using EMS.DataAccessLayer.DatabaseStorage;
using EMS.EnterpriseLibrary;
using EMS.EnterpriseLibrary.Unity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BusinessImplementation
{
    public class EmployeeIdentityManager : IEmployeeIdentityManager
    {
        public BusinessLayerEmployee Authenticate(BusinessLayerCredential credential)
        {
            BusinessLayerEmployee employee;
            IUnityContainer container = Factory.GetUnityConfiguration();
            IEmployeeStorageIdentity dataManager = container.Resolve<IEmployeeStorageIdentity>();
            employee = dataManager.Authenticate(credential);
            return employee;
        }
        public BusinessLayerEmployee ChangePassword(BusinessLayerChangePassword changePassword)
        {
            BusinessLayerEmployee employee = null;
            IUnityContainer container = Factory.GetUnityConfiguration();
            IEmployeeStorageIdentity dataManager = container.Resolve<IEmployeeStorageIdentity>();
            employee = dataManager.ChangePassword(changePassword);
            return employee;

        }
    }
}
