using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tavisca.Templar.Contract;

namespace TemplarEMS.Account
{
    public partial class Logout : System.Web.UI.UserControl,IWidget
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session.Abandon();
                HttpCookie cookies = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
                cookies.Expires = DateTime.Now.AddDays(-1);
                Context.Response.Cookies.Add(cookies);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Response.Redirect("Login");
            }
        }

        public void HideSettings()
        {
           
        }

        public new void Init(IWidgetHost host)
        {
           
        }

        public void ShowSettings()
        {
           
        }
    }
}