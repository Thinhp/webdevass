using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webdev_Assignment2.Entities
{
    public partial class medicalservicegroupdetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void back_button_Click(object sender, EventArgs e)
        {
            var response = Page.Response;
            response.Redirect("medicalservicegroup.aspx", false);
        }
    }
}