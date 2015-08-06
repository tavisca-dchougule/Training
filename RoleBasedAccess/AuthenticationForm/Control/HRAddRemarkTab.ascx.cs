﻿
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
    public partial class HRAddRemarkTab : System.Web.UI.UserControl
    {
        Dictionary<string, string> Dictionary = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                GetAllEmployeeResponse employeeListResponse = GetAllEmployeeResponse.GetAllEmployee();
                List<Employee> employeeList = null;
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
            RemarkResponse responseRemark = remark.AddRemark(selectedEmployee);
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
            Response.Redirect("ChangePassword.aspx");
        }
       
    }
}