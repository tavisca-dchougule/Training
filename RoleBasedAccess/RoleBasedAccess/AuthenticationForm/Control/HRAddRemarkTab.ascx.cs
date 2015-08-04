using AuthenticationForm.Model;
using RoleBasedAccess.EnterpriseLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuthenticationForm
{
    public partial class HRAddRemarkTab : System.Web.UI.UserControl
    {
        Dictionary<string, string> Dictionary = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                var client = new HttpClient();
                GetAllEmployeeResponse employeeListResponse = null;
                List<Employee> employeeList = null;
                try
                {
                    string employeeServiceUrl = ConfigurationManager.AppSettings["employeeserviceurl"];
                    employeeListResponse = client.GetData<GetAllEmployeeResponse>(employeeServiceUrl + "getall");
                }
                catch(Exception ex)
                {
                    ExceptionPolicy.HandleException("MyPolicy", ex);
                }
                if (string.Equals(employeeListResponse.Status.StatusCode, "200", StringComparison.OrdinalIgnoreCase) == false)
                {
                    LabelAddRemark.Visible = true;
                    LabelAddRemark.Text = "Employee Fetch Failed.";
                    return;
                }
                employeeList = employeeListResponse.AllEmployeeList;
                for (int i = 0; i < employeeList.Count(); i++)
                {
                    Employee tempEmployee = employeeList.ElementAt(i);
                    Dictionary.Add(tempEmployee.Id.Trim(), tempEmployee.Id.Trim() + " " + tempEmployee.FirstName.Trim() + " " + tempEmployee.LastName.Trim());
                }
                DropDownListEmp.DataTextField = "Value";
                DropDownListEmp.DataValueField = "Key";
                DropDownListEmp.DataSource = Dictionary;
                DropDownListEmp.DataBind();
            }
        }

        protected void ButtonSubmitRemark_Click(object sender, EventArgs e)
        {
            string selectedEmployee = DropDownListEmp.SelectedValue;
            Remark remark = new Remark();
            remark.DateTime = DateTime.UtcNow;
            remark.Text = TextBoxRemark.Text;
            HttpClient client = new HttpClient();
            RemarkResponse responseRemark = null;
            try
            {
                string employeeManagementServiceUrl = ConfigurationManager.AppSettings["employeemanagementserviceurl"];
                responseRemark = client.UploadData<Remark, RemarkResponse>(employeeManagementServiceUrl + "employee/" + selectedEmployee + "/addremark", remark);
            }
            catch(Exception ex)
            {
                ExceptionPolicy.HandleException("MyPolicy", ex);
            }
            if (string.Equals(responseRemark.Status.StatusCode, "200", StringComparison.OrdinalIgnoreCase) == false)
            {
                LabelAddRemark.Visible = true;
                LabelAddRemark.Text = "Add Remark Failed.";
                return;
            }
            LabelAddRemark.Visible = true;
            LabelAddRemark.Text = "Remark Added Successfully.";
             

        }

        protected void OnChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ChangePassword.aspx");
        }
       
    }
}