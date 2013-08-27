using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webdev_Assignment2
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null || !Session["Username"].Equals(""))
            {
                WelcomeLabel.Text = "Welcome  " + (string)Session["Username"];
            }


        }

        protected void LogoutLinkButton_Click(object sender, EventArgs e)
        {
            var response = base.Response;
            Session["Username"] = "";
            Session["Password"] = "";
            Session["Role"] = "";
            response.Redirect("http://localhost:37730/index.aspx", false);
        }

    }
}