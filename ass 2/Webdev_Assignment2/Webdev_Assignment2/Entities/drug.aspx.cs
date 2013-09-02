using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Webdev_Assignment2.Entities
{
    public partial class drug : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataBaseServerDataContext db = new DataBaseServerDataContext();
                var thelist = from p in db.DrugGroups
                              select p.GroupName;

                DrugGroupTextBox.DataSource = thelist.ToArray();
                DrugGroupTextBox.DataBind();
            }

        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            //Make it sleeps a bit
            System.Threading.Thread.Sleep(1000);

            //Bind data
            this.GridView1.DataBind();

        }

        protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            //Get the linq command and put 'e' paramter result equal to the variable
            DataBaseServerDataContext db = new DataBaseServerDataContext();
            string searchkey = SearchField.Text;

            var searched = from p in db.Drugs
                           where p.Name.Contains(searchkey)
                           || p.GenericName.Contains(searchkey)
                           || p.Id.ToString().Contains(searchkey)
                           || p.Price.ToString().Contains(searchkey)
                           //|| p.DrugGroup.ToString().Contains(searchkey)
                           select p;

            e.Result = searched;
        }

        protected void InsertButton_Click(object sender, EventArgs e)
        {
            //Check validation
            if (IsValid)
            {
                DataBaseServerDataContext db = new DataBaseServerDataContext();
                var name = NameTextBox.Text;
                var generic = GenericNameTextBox.Text;
                var unit = UnitTextBox.Text;
                var price = PriceTextBox.Text;

                //Get Dropbox list menu item and check with id
                var drug = DrugGroupTextBox.SelectedValue;
                var allId = from g in db.DrugGroups
                            select g;

                int targetId = 0;
                foreach (var n in allId)
                {
                    if (n.GroupName.Equals(drug))
                    {
                        targetId = n.Id;
                        break;
                    }
                }

                var insert = new Drug()
                {
                    Name = name,
                    GenericName = generic,
                    Unit = Int32.Parse(unit),
                    Price = Decimal.Parse(price),
                    DrugGroupId = targetId
                };

                db.Drugs.InsertOnSubmit(insert);
                db.SubmitChanges();
                GridView1.DataBind();

                //reset field
                NameTextBox.Text = "";
                GenericNameTextBox.Text = "";
                UnitTextBox.Text = "";
                PriceTextBox.Text = "";

                StringBuilder sb = new StringBuilder();
                sb.Append("toggle_visibility('SuccessBoxMessage');");

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "successdrug", sb.ToString(), true);

            }

        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static string[] GetCompletionList(string prefixText)
        {
            DataBaseServerDataContext db = new DataBaseServerDataContext();
            var result = (from n in db.Drugs
                          where n.Id.ToString().ToLower().Contains(prefixText.ToLower())
                          select n.Id.ToString())
                         .Union(from n in db.Drugs
                                where n.Name.ToLower().Contains(prefixText.ToLower())
                                select n.Name)
                                .Union(from n in db.Drugs
                                       where n.GenericName.Contains(prefixText.ToLower())
                                       select n.GenericName)
                                       .Union(from n in db.Drugs
                                              where n.Unit.ToString().ToLower().Contains(prefixText.ToLower())
                                              select n.Unit.ToString())
                                              .Union(from n in db.Drugs
                                                     where n.Price.ToString().ToLower().Contains(prefixText.ToLower())
                                                     select n.Price.ToString())
                                                     .Union(from n in db.DrugGroups
                                                            where n.Id.ToString().ToLower().Contains(prefixText.ToLower())
                                                            select n.Id.ToString())
                                                            .Union(from n in db.DrugGroups
                                                                   where n.GroupName.ToLower().Contains(prefixText.ToLower())
                                                                   select n.GroupName);

            return result.ToArray();
        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            DataBaseServerDataContext db = new DataBaseServerDataContext();
            if (Roles.IsUserInRole("user"))
            {
                panel_insert.Visible = false;
                for (int i = 1; i < GridView1.Rows.Count + 1; i++)
                {
                    GridView1.Controls[0].Controls[i].FindControl("LinkButton1").Visible = false;
                    GridView1.Controls[0].Controls[i].FindControl("LinkButton2").Visible = false;
                }

            }

            //Change the id row

            //for (int i = 0; i < GridView1.Rows.Count; i++)
            //{

            //    Label text = GridView1.Rows[i].FindControl("DrugGroupNormal") as Label;
            //    var allquery = from n in db.DrugGroups
            //                   where n.Id.ToString().Equals(text.Text)
            //                   select new
            //                   {
            //                       n.Id,
            //                       n.GroupName
            //                   };

            //    foreach (var que in allquery)
            //    {
            //        if (que.Id.ToString().Equals(text.Text))
            //        {
            //            text.Text = que.GroupName;
            //            break;
            //        }
            //    }


            //}

            //bind 2 source but don't use anymore
            //var drugsource = from n in db.Drugs
            //                 join g in db.DrugGroups
            //                     on n.DrugGroupId
            //                     equals g.Id
            //                 select new
            //                 {
            //                     Id = n.Id,
            //                     Name = n.Name,
            //                     GenericName = n.GenericName,
            //                     Unit = n.Unit,
            //                     Price = n.Price,
            //                     DrugGroupId = n.DrugGroupId,
            //                     DrugGroup = g.GroupName,
            //                 };

            //GridView1.DataSource = drugsource;
            //GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void DrugGroupTextBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DataBaseServerDataContext db = new DataBaseServerDataContext();
        //    var thelist = from p in db.DrugGroups
        //                  select p;


        //    DrugGroupTextBox.DataSource = thelist.ToArray();
        //    DrugGroupTextBox.DataBind();
        //}
    }
}