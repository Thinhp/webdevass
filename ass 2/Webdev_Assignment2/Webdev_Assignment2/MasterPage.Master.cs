using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webdev_Assignment2
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        protected void LogoutLinkButton_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Response.Redirect("~/index.aspx",false);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            var response = base.Response;
            response.Redirect("~/Entities/doctor.aspx", false);
        }

        protected void HomeButton_Click(object sender, EventArgs e)
        {
            var response = base.Response;
            response.Redirect("~/home.aspx", false);
        }

        protected void AboutButton_Click(object sender, EventArgs e)
        {

        }

    }
}