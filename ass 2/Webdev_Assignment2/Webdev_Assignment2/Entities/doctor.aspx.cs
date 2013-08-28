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
            System.Threading.Thread.Sleep(2000);
            string searchkey = SearchField.Text;

            using (DataBaseServerDataContext db = new DataBaseServerDataContext())
            {
                var query = db.Doctors.Where(x => x.Name == searchkey).ToList();
                this.GridView1.DataSource = query;
                this.GridView1.DataSourceID = string.Empty;
                this.GridView1.DataBind();
            }

        }

        protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {

        }
    }
}