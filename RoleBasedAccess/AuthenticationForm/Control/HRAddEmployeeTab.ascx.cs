using AuthenticationForm.Model;
using RoleBasedAccess.EnterpriseLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuthenticationForm
{
    public partial class HRAddEmployeeTab : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        protected void ButtonEmpSubmit_Click(object sender, EventArgs e)
        {   
            Employee employee = new Employee();
            employee.FirstName = TextBoxFirstName.Text;
            employee.LastName =TextBoxLastName.Text;
            employee.Title = TextBoxTitle.Text;
            employee.Email = TextBoxEmail.Text;
            employee.Designation =  TextBoxDesignation.Text;
            employee.Password = employee.FirstName;
            EmployeeResponse responseEmployee = null;
            var client = new HttpClient();
            try
            {
                string EmployeeManagementServiceUrl = ConfigurationManager.AppSettings["employeemanagementserviceurl"];
                responseEmployee = client.UploadData<Employee, EmployeeResponse>(EmployeeManagementServiceUrl + "create", employee);
            }
            catch(Exception ex)
            {
                ExceptionPolicy.HandleException("MyPolicy", ex);
            }
            if (string.Equals(responseEmployee.Status.StatusCode, "200", StringComparison.OrdinalIgnoreCase) == false)
            {
                LabelCreateEmployee.Visible = true;
                LabelCreateEmployee.Text = "Employee Creation Failed.";
                return;
            }
            LabelCreateEmployee.Visible = true;
            LabelCreateEmployee.Text = "Employee Created Succesfully.";       
        }
        protected void OnChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }
    }
}
