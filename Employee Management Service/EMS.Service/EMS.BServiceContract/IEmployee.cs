
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using EMS.BDataContract;


namespace EMS.BServiceContract
{

    public interface IEmployee
    {

        BusinessEmployee GetEmployee(string employeeId);


        List<BusinessEmployee> GetAll();
    }
}
