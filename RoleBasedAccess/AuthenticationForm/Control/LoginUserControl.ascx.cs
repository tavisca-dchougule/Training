using AuthenticationForm.Model;
using RoleBasedAccess.EnterpriseLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuthenticationForm
{
    public partial class LoginUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Credential credential=new Credential();
            credential.UserName = UsernameTextbox.Text;
            credential.Password = PasswordTextbox.Text;
            
            var client = new HttpClient();
            EmployeeResponse employeeResponse = null;
            Employee employee = null;
            try
            {
                string employeeManagementServiceUrl = ConfigurationManager.AppSettings["employeeidentityurl"];
                employeeResponse = client.UploadData<Credential, EmployeeResponse>(employeeManagementServiceUrl +"/authenticate",credential );
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException("MyPolicy", ex);
            }

            if (string.Equals(employeeResponse.Status.StatusCode, "200",StringComparison.OrdinalIgnoreCase)==false)
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
                if(string.Equals(employee.Designation.Trim(),"hr",StringComparison.OrdinalIgnoreCase))
                    returnUrl = "~/Hr/HRAddEmployee.aspx";
                else
                    returnUrl = "~/Employee/EmployeePage.aspx";
            }
            else
            {
                returnUrl = Request.QueryString["ReturnUrl"];
            }
            Response.Redirect(returnUrl);
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}