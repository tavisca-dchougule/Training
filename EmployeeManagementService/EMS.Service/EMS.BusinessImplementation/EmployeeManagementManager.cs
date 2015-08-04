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
    public class EmployeeManagementManager : IEmployeeManagementManager
    {
        public BusinessLayerEmployee Create(BusinessLayerEmployee employee)
        {
            IUnityContainer container = Factory.GetUnityConfiguration();
            IEmployeeStoragePostCall dataManager = container.Resolve<IEmployeeStoragePostCall>();
            BusinessLayerEmployee businessEmployee=dataManager.Save(employee);
            ICacheManager cacheManager = null;
            cacheManager = container.Resolve<ICacheManager>();
            cacheManager.Add(employee.Id, employee);
            return businessEmployee;
        }
        public BusinessLayerRemark AddRemark(string employeeId, BusinessLayerRemark remark)
        {
            IUnityContainer container = Factory.GetUnityConfiguration();
            IEmployeeStoragePostCall dataManager = container.Resolve<IEmployeeStoragePostCall>();
            dataManager.AddRemark(employeeId, remark);
            return remark;
        }
    }
}
