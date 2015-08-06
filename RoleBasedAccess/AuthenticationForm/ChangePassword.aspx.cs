
using RoleBasedAccess.EnterpriseLibrary;
using RoleBasedAccess.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuthenticationForm
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Submit_Button_Clicked(object sender, EventArgs e)
        {
            ChangeCredential changeCredential = new ChangeCredential();
            changeCredential.UserName = Session["userName"].ToString();
            changeCredential.OldPassword = TextBoxOldPassword.Text;
            changeCredential.NewPassword = TextBoxNewPassword.Text;

            EmployeeResponse responseEmployee=changeCredential.CredentialChange();
           
            if (string.Equals(responseEmployee.Status.StatusCode,"200", StringComparison.OrdinalIgnoreCase) == false)
            {
                LabelChangePassword.Visible = true;
                LabelChangePassword.Text = "Change Password Failed.";
                return;
            }
            LabelChangePassword.Visible = true;
            LabelChangePassword.Text = "Password Changed Succesfully.";
        }
    }
}