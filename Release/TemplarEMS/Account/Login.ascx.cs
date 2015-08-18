using RoleBasedAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tavisca.Templar.Contract;

namespace TemplarEMS.Account
{
    public partial class Login : System.Web.UI.UserControl, IWidget
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void HideSettings()
        {
            Panel1.Visible = false;
        }

        public new void Init(IWidgetHost host)
        {
            
        }

        public void ShowSettings()
        {
            Panel1.Visible = true;
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Credential credential = new Credential();
            credential.UserName = UsernameTextbox.Text;
            credential.Password = PasswordTextbox.Text;

            EmployeeResponse employeeResponse = credential.Authenticate();
            Employee employee = null;
            if (string.Equals(employeeResponse.Status.StatusCode, "200", StringComparison.OrdinalIgnoreCase) == false)
            {
                LabelLoginState.Visible = true;
                LabelLoginState.Text = "Login Failed.";
                return;
            }
            employee = employeeResponse.Employee;

            FormsAuthentication.SetAuthCookie(employee.Email.Trim(), false);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, employee.Email.Trim(), DateTime.UtcNow, DateTime.UtcNow.AddMinutes(10), false, employee.Designation.Trim().ToLower());
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            Response.Cookies.Add(cookie);
            Session["employeeId"] = employee.Id.Trim();
            Session["userName"] = employee.Email.Trim();
            Session["employeeRole"] = employee.Designation.Trim();

            String returnUrl;
            if (Request.QueryString["ReturnUrl"] == null)
            {
                if (string.Equals(employee.Designation.Trim(), "hr", StringComparison.OrdinalIgnoreCase))
                    returnUrl = "HrAddEmployee";
                else
                    returnUrl = "EmployeePage";
            }
            else
            {
                returnUrl = Request.QueryString["ReturnUrl"];
            }
            Response.Redirect(returnUrl);
        }
    }
}