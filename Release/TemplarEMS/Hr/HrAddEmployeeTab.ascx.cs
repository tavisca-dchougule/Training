using RoleBasedAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tavisca.Templar.Contract;

namespace TemplarEMS.Hr
{
    public partial class HrAddEmployeeTab : System.Web.UI.UserControl, IWidget
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ButtonEmpSubmit_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.FirstName = TextBoxFirstName.Text;
            employee.LastName = TextBoxLastName.Text;
            employee.Title = TextBoxTitle.Text;
            employee.Email = TextBoxEmail.Text;
            employee.Designation = TextBoxDesignation.Text;
            employee.Password = employee.FirstName;
            EmployeeResponse responseEmployee = employee.CreateEmployee();
            if (string.Equals(responseEmployee.Status.StatusCode, "200", StringComparison.OrdinalIgnoreCase) == false)
            {
                LabelCreateEmployee.Visible = true;
                LabelCreateEmployee.Text = "Employee Creation Failed.";
                return;
            }
            LabelCreateEmployee.Visible = true;
            LabelCreateEmployee.Text = "Employee Created Succesfully.";
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
    }
}