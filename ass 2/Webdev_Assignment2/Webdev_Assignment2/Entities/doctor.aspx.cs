using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webdev_Assignment2.Entities
{
    public partial class doctor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string searchkey = SearchField.Text;

            System.Threading.Thread.Sleep(3000);
        }
    }
}