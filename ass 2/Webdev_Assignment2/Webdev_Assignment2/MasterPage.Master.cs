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
            if (Session["Username"] != null && !Session["Username"].Equals(""))
            {
                WelcomeLabel.Text = "Welcome  " + (string)Session["Username"];
            }
            else
            {
                var response = base.Response;
                response.Redirect("~/error.aspx",false);
            }


        }

        protected void LogoutLinkButton_Click(object sender, EventArgs e)
        {
            var response = base.Response;
            Session["Username"] = "";
            Session["Password"] = "";
            Session["Role"] = "";
            response.Redirect("~/index.aspx", false);
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