using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BusinessDataContract
{
    public class BusinessLayerChangePassword
    {
        public string OldPassword
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }
        public string NewPassword
        {
            get;
            set;
        }

        public BusinessLayerChangePassword(string userName, string oldPassword, string newPassword)
        {
            this.UserName = userName;
            this.NewPassword = newPassword;
            this.OldPassword = oldPassword;
        }
    }
}
