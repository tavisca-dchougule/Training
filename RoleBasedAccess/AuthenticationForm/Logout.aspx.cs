using RoleBasedAccess.EnterpriseLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuthenticationForm
{
    public partial class WebForm4 : System.Web.UI.Page
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
                ExceptionPolicy.HandleException("MyPolicy", ex);
            }
            finally
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}