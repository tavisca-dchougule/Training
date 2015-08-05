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
    public partial class WebForm2 : System.Web.UI.Page
    {

        string EmployeeServiceUrl = null;
        HttpClient client = null;
        public WebForm2()
        {
            client = new HttpClient();
            try
            {
                EmployeeServiceUrl = ConfigurationManager.AppSettings["employeeserviceurl"];
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException("MyPolicy", ex);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                if (Session.IsNewSession == true)
                    Response.Redirect("~/Login.aspx");
                string employeeId = Session["employeeId"].ToString();
                PaginationRemarkListResponse remarkListResponse = null;
                RemarkCountResponse remarkCountResponse = null;
                try
                {
                    remarkCountResponse = client.GetData<RemarkCountResponse>(EmployeeServiceUrl + "employee/" + employeeId + "/getremarkcount");
                    if (string.Equals(remarkCountResponse.Status.StatusCode, "200", StringComparison.OrdinalIgnoreCase) == false)
                    {
                        LabelFetchRemark.Visible = true;
                        LabelFetchRemark.Text = "Fetch Remark Failed.";
                        return;
                    }
                    GridViewRemark.VirtualItemCount = remarkCountResponse.RemarkCount;

                    remarkListResponse = client.GetData<PaginationRemarkListResponse>(EmployeeServiceUrl + "employee/" + employeeId + "/" + 1 + "/" + 3 + "/getremark");
                    if (string.Equals(remarkListResponse.Status.StatusCode, "200", StringComparison.OrdinalIgnoreCase) == false)
                    {
                        LabelFetchRemark.Visible = true;
                        LabelFetchRemark.Text = "Fetch Remark Failed.";
                        return;
                    }

                    GridViewRemark.DataSource = remarkListResponse.PaginationRemarkList;
                    GridViewRemark.DataBind();
                }
                catch (Exception ex)
                {
                    ExceptionPolicy.HandleException("MyPolicy", ex);
                }
            }
        }

        protected void GridViewRemark_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridViewRemark_SelectedIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PaginationRemarkListResponse remarkListResponse = null;
            try
            {
                string employeeId = Session["employeeId"].ToString();
                GridViewRemark.PageIndex = e.NewPageIndex;
               remarkListResponse  = client.GetData<PaginationRemarkListResponse>(EmployeeServiceUrl + "employee/" + employeeId + "/" + (GridViewRemark.PageIndex + 1) + "/" + 3 + "/getremark");
            }
            catch(Exception ex)
            {
                ExceptionPolicy.HandleException("MyPolicy", ex);
            }
            if (string.Equals(remarkListResponse.Status.StatusCode, "200", StringComparison.OrdinalIgnoreCase) == false)
            {
                LabelFetchRemark.Visible = true;
                LabelFetchRemark.Text = "Fetch Remark Failed.";
                return;
            }
            GridViewRemark.DataSource = remarkListResponse;
            GridViewRemark.DataBind();
        }


        protected void OnChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ChangePassword.aspx");
        }
    }
}