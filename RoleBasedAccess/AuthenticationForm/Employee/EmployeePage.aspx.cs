
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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                if (Session.IsNewSession == true)
                    Response.Redirect("~/Login.aspx");
                string employeeId = Session["employeeId"].ToString();
                RemarkCountResponse remarkCountResponse = RemarkCountResponse.GetRemarkCount(employeeId);

                if (string.Equals(remarkCountResponse.Status.StatusCode, "200", StringComparison.OrdinalIgnoreCase) == false)
                {
                    LabelFetchRemark.Visible = true;
                    LabelFetchRemark.Text = "Fetch Remark Failed.";
                    return;
                }
                GridViewRemark.VirtualItemCount = remarkCountResponse.RemarkCount;

                PaginationRemarkListResponse remarkListResponse = PaginationRemarkListResponse.GetRemarkList(employeeId);
                if (string.Equals(remarkListResponse.Status.StatusCode, "200", StringComparison.OrdinalIgnoreCase) == false)
                {
                    LabelFetchRemark.Visible = true;
                    LabelFetchRemark.Text = "Fetch Remark Failed.";
                    return;
                }
                GridViewRemark.DataSource = remarkListResponse.PaginationRemarkList;
                GridViewRemark.DataBind();
            }
        }
        protected void GridViewRemark_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridViewRemark_SelectedIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string employeeId = Session["employeeId"].ToString();
            GridViewRemark.PageIndex = e.NewPageIndex;
            PaginationRemarkListResponse remarkListResponse = PaginationRemarkListResponse.GetRemarkList(employeeId);

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