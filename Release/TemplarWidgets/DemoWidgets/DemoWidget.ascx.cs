using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tavisca.Templar.Contract;

namespace TemplarWidgets.DemoWidgets
{
    public partial class DemoWidget : System.Web.UI.UserControl,IWidget
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string firstName=TextBoxFirstName.Text;
            string lastName = TextBoxLastName.Text;
            LabelDisplay.Visible = true;
            LabelDisplay.Text = firstName + " " + lastName;
        }

        public void HideSettings()
        {
           // throw new NotImplementedException();
        }

        public new void Init(IWidgetHost host)
        {
           // throw new NotImplementedException();
        }

        public void ShowSettings()
        {
           // throw new NotImplementedException();
        }
    }
}