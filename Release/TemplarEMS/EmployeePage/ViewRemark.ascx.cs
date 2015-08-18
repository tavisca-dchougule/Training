using RoleBasedAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tavisca.Templar.Contract;

namespace TemplarEMS.EmployeePage
{
    public partial class ViewRemark : System.Web.UI.UserControl, IWidget
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                if (Session.IsNewSession == true)
                    Response.Redirect("Login");
                string employeeId = Session["employeeId"].ToString();
                RemarkCountResponse remarkCountResponse = RemarkCountResponse.GetRemarkCount(employeeId);

                if (string.Equals(remarkCountResponse.Status.StatusCode, "200", StringComparison.OrdinalIgnoreCase) == false)
                {
                    LabelFetchRemark.Visible = true;
                    LabelFetchRemark.Text = "Fetch Remark Failed.";
                    return;
                }
                GridViewRemark.VirtualItemCount = remarkCountResponse.RemarkCount;

                PaginationRemarkListResponse remarkListResponse = PaginationRemarkListResponse.GetRemarkList(employeeId, "1", "3");
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
            PaginationRemarkListResponse remarkListResponse = PaginationRemarkListResponse.GetRemarkList(employeeId, "" + (GridViewRemark.PageIndex + 1), "3");

            if (string.Equals(remarkListResponse.Status.StatusCode, "200", StringComparison.OrdinalIgnoreCase) == false)
            {
                LabelFetchRemark.Visible = true;
                LabelFetchRemark.Text = "Fetch Remark Failed.";
                return;
            }
            GridViewRemark.DataSource = remarkListResponse.PaginationRemarkList;
            GridViewRemark.DataBind();
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