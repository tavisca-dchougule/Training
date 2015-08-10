using RoleBasedAccess.Model;
using RoleBasedAccessMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoleBasedAccessMVC.Controllers
{
    [Authorize]
    public class HrController : Controller
    {
          [Authorize(Roles = "HR")]
        public ActionResult AddEmployee()
        {
            ViewData["Success"]="";
            return View("AddEmployee");
        }
          [Authorize(Roles = "HR")]
        public ActionResult SaveEmployee(Employee model)
        {
            
            EmployeeResponse responseEmployee = null;
            try
            {
                 responseEmployee = model.CreateEmployee();
            }
            catch (Exception e)
            {
            }
            if (string.Equals(responseEmployee.Status.StatusCode, "200", StringComparison.OrdinalIgnoreCase) == false)
            {
                ViewData["Success"] = "Employee Creadtion Failed";
                ModelState.Clear();
                return View("AddEmployee");
                
            }
            ViewData["Success"] = "Employee Creadtion Successful";
            ModelState.Clear();
            return View("AddEmployee");
        }
          [Authorize(Roles = "HR")]
        public ActionResult AddRemark()
        {

            ViewData["Success"] = "";
            ViewData["RemarkList"] = this.GetAllEmployee();
            if(ViewData["Success"].ToString().Equals(""))
            ViewData["Success"] = "";
            
            return View("AddRemark");
        }
          [Authorize(Roles = "HR")]
        private List<SelectListItem> GetAllEmployee()
        {
            GetAllEmployeeResponse employeeListResponse = GetAllEmployeeResponse.GetAllEmployee();

            if (string.Equals(employeeListResponse.Status.StatusCode, "200", StringComparison.OrdinalIgnoreCase) == false)
            {
                ViewData["Success"] = "Fetch Employee Failed";
            }
            List<Employee> employeeList = employeeListResponse.AllEmployeeList;
            List<SelectListItem> employeeDetails = new List<SelectListItem>();
            foreach (var employee in employeeList)
            {
                employeeDetails.Add(new SelectListItem { Text = (employee.FirstName.Trim() + " " + employee.LastName.Trim()), Value = employee.Id.Trim() });
            }
            return employeeDetails;

        }
          [Authorize(Roles = "HR")]
        public ActionResult SaveRemark(Remark model)
        {
            model.DateTime = DateTime.UtcNow;

            string selectedEmployee = Request["SelectedEmployee"].ToString();
            RemarkResponse responseRemark = model.AddRemark(selectedEmployee);
           
            if (string.Equals(responseRemark.Status.StatusCode, "200", StringComparison.OrdinalIgnoreCase) == false)
            {
                ViewData["Success"]= "Add Remark Failed";
                ModelState.Clear();
                return View("AddRemark");
            }
            ViewData["Success"] = "Add Remark Successful";
            ViewData["RemarkList"] = this.GetAllEmployee();
            ModelState.Clear();
            return View("AddRemark");
        }

    }
}
