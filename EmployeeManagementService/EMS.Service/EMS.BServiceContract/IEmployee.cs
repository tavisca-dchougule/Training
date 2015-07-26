
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using EMS.BusinessDataContract;


namespace EMS.BServiceContract
{

    public interface IEmployee
    {

        BusinessLayerEmployee GetEmployee(string employeeId);


        List<BusinessLayerEmployee> GetAll();
    }
}
