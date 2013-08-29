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
        string tempId;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(1000);
            //string searchkey = SearchField.Text;
            //tempId = this.GridView1.DataSourceID;

            //using (DataBaseServerDataContext db = new DataBaseServerDataContext())
            //{
            //    //var query = db.Doctors.Where(x => x.Name == searchkey).ToList();

            //    var searched = from p in db.Doctors
            //                   where p.Name.Contains(searchkey)
            //                   || p.Licensenumber.Contains(searchkey)
            //                   || p.Id.ToString().Contains(searchkey)
            //                   || p.Address.Contains(searchkey)
            //                   select p;

            //    this.GridView1.DataSource = searched;
            //    this.GridView1.DataSourceID = string.Empty;
                this.GridView1.DataBind();

                //this.GridView1.DataSourceID = tempId;
            //}
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            DataBaseServerDataContext db = new DataBaseServerDataContext();
            string searchkey = SearchField.Text;

            var searched = from p in db.Doctors
                           where p.Name.Contains(searchkey)
                           || p.Licensenumber.Contains(searchkey)
                           || p.Id.ToString().Contains(searchkey)
                           || p.Address.Contains(searchkey)
                           select p;

            e.Result = searched;
        }



    }
}