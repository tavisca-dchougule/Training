using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tavisca.Templar.Contract;

namespace TemplarEMS.Shared
{
    public partial class Header : System.Web.UI.UserControl, IWidget
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButtonChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword");
        }

        protected void LinkButtonLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logout");
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