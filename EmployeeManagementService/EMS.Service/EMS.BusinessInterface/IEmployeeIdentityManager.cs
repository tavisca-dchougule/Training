using EMS.BDataContract;
using EMS.BusinessDataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BusinessInterface
{
    public interface IEmployeeIdentityManager
    {
        BusinessLayerEmployee Authenticate(BusinessLayerCredential credential);
        BusinessLayerEmployee ChangePassword(BusinessLayerChangePassword changePassword);
    }
}
