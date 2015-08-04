using EMS.BusinessDataContract;
using EMS.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Translator
{
    public class ChangePasswordTranslator
    {
        public BusinessLayerChangePassword ConvertToBusinessChangePassword(ChangeCredential changePassword)
        {
            BusinessLayerChangePassword businessChangePassword;
            if (changePassword == null)
                businessChangePassword = null;
            else
                businessChangePassword = new BusinessLayerChangePassword(changePassword.UserName, changePassword.OldPassword, changePassword.NewPassword);

            return businessChangePassword;
        }
        public ChangeCredential ConvertToServiceChangePassword(BusinessLayerChangePassword changePassword)
        {
            ChangeCredential serviceChangePassword;
            if (changePassword == null)
                serviceChangePassword = null;
            else
                serviceChangePassword = new ChangeCredential(changePassword.UserName, changePassword.OldPassword, changePassword.NewPassword);

            return serviceChangePassword;
        }
    }
}
