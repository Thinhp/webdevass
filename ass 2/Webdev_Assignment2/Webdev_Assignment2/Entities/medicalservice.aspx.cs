using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webdev_Assignment2.Entities
{
    public partial class medicalservice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataBaseServerDataContext db = new DataBaseServerDataContext();
                var thelist = from p in db.MedicalServiceGroups
                              select p.ServiceGroup;

                MedicalServiceGroupTextBox.DataSource = thelist.ToArray();
                MedicalServiceGroupTextBox.DataBind();
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            //Make it sleeps a bit
            System.Threading.Thread.Sleep(1000);

            //Bind data
            this.GridView1.DataBind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            //Get the linq command and put 'e' paramter result equal to the variable
            DataBaseServerDataContext db = new DataBaseServerDataContext();
            string searchkey = SearchField.Text;

            var searched = from p in db.MedicalServices
                           join g in db.MedicalServiceGroups
                           on p.ServiceGroupId equals g.Id
                           where p.Id.ToString().Contains(searchkey) 
                           || p.ServiceName.Contains(searchkey)
                           || p.Price.ToString().Contains(searchkey)
                           || g.ServiceGroup.Contains(searchkey)
                           || g.Id.ToString().Contains(searchkey)
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
                var price = PriceTextBox.Text;
                var medicalgroup = MedicalServiceGroupTextBox.SelectedValue;
                var all = from g in db.MedicalServiceGroups
                          select g;

                int targetId = 0;
                foreach (var n in all)
                {
                    if (n.ServiceGroup.Equals(medicalgroup))
                    {
                        targetId = n.Id;
                        break;
                    }
                }


                var insert = new MedicalService()
                {
                    ServiceName = name,
                    Price = Decimal.Parse(price),
                    ServiceGroupId = targetId
                };

                db.MedicalServices.InsertOnSubmit(insert);
                db.SubmitChanges();
                GridView1.DataBind();

                //reset field
                NameTextBox.Text = "";
                PriceTextBox.Text = "";

                StringBuilder sb = new StringBuilder();
                sb.Append("toggle_visibility('SuccessBoxMessage');");

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "successmedicalservice", sb.ToString(), true);

            }

        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static string[] GetCompletionList(string prefixText)
        {
            DataBaseServerDataContext db = new DataBaseServerDataContext();
            var result = (from n in db.MedicalServices
                          where n.Id.ToString().ToLower().Contains(prefixText.ToLower())
                          select n.Id.ToString())
                         .Union(from n in db.MedicalServices
                                where n.ServiceName.ToLower().Contains(prefixText.ToLower())
                                select n.ServiceName)
                                .Union(from n in db.MedicalServices
                                       where n.Price.ToString().Contains(prefixText.ToLower())
                                       select n.Price.ToString())
                                       .Union(from n in db.MedicalServiceGroups
                                              where n.Id.ToString().Contains(prefixText.ToLower())
                                              select n.Id.ToString())
                                              .Union(from n in db.MedicalServiceGroups
                                                     where n.ServiceGroup.ToLower().Contains(prefixText.ToLower())
                                                     select n.ServiceGroup);

            return result.ToArray();
        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            if (Roles.IsUserInRole("user"))
            {
                panel_insert.Visible = false;
                for (int i = 1; i < GridView1.Rows.Count + 1; i++)
                {
                    GridView1.Controls[0].Controls[i].FindControl("LinkButton1").Visible = false;
                    GridView1.Controls[0].Controls[i].FindControl("LinkButton2").Visible = false;
                }

            }
        }
    }
}