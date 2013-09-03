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
    public partial class prescriptioninfo : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataBaseServerDataContext db = new DataBaseServerDataContext();
                var thelist = from p in db.Drugs
                              select p.Name;

                DrugNameDropDown.DataSource = thelist.ToArray();
                DrugNameDropDown.DataBind();
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

            var searched = from p in db.PrescriptionDetails
                           join g in db.Drugs
                           on p.DrugId equals g.Id
                           where p.Id.ToString().Contains(searchkey)
                           || p.Quantity.ToString().Contains(searchkey)
                           || p.DosePerDay.ToString().Contains(searchkey)
                           || p.SpecialInstruction.ToString().Contains(searchkey)
                           || g.Id.ToString().Contains(searchkey)
                           || g.Name.Contains(searchkey)
                           select p;

            e.Result = searched;
        }

        protected void InsertButton_Click(object sender, EventArgs e)
        {
            //Check validation
            if (IsValid)
            {
                DataBaseServerDataContext db = new DataBaseServerDataContext();
                var name = DrugNameDropDown.SelectedValue;
                var quantity = QuantityTextBox.Text;
                var dose = DoseTextBox.Text;
                var instruction = SpecialTextBox.Text;

                //Get Dropbox list menu item and check with id
                var allId = from g in db.Drugs
                            select g;

                int targetId = 0;
                foreach (var n in allId)
                {
                    if (n.Name.Equals(name))
                    {
                        targetId = n.Id;
                        break;
                    }
                }

                var insert = new PrescriptionDetail()
                {
                    Quantity = Int32.Parse(quantity),
                    DosePerDay = Int32.Parse(dose),
                    SpecialInstruction = instruction,
                    DrugId = targetId
                };

                db.PrescriptionDetails.InsertOnSubmit(insert);
                db.SubmitChanges();
                GridView1.DataBind();

                //reset field
                QuantityTextBox.Text = "";
                DoseTextBox.Text = "";
                SpecialTextBox.Text = "";

                StringBuilder sb = new StringBuilder();
                sb.Append("toggle_visibility('SuccessBoxMessage');");

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "successprescriptioninfo", sb.ToString(), true);

            }

        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static string[] GetCompletionList(string prefixText)
        {
            DataBaseServerDataContext db = new DataBaseServerDataContext();
            var result = (from n in db.PrescriptionDetails
                          where n.Id.ToString().ToLower().Contains(prefixText.ToLower())
                          select n.Id.ToString())
                         .Union(from n in db.PrescriptionDetails
                                where n.Quantity.ToString().ToLower().Contains(prefixText.ToLower())
                                select n.Quantity.ToString())
                                .Union(from n in db.PrescriptionDetails
                                       where n.DosePerDay.ToString().Contains(prefixText.ToLower())
                                       select n.DosePerDay.ToString())
                                       .Union(from n in db.PrescriptionDetails
                                              where n.SpecialInstruction.ToLower().Contains(prefixText.ToLower())
                                              select n.SpecialInstruction)
                                              .Union(from n in db.Drugs
                                                     where n.Name.ToLower().Contains(prefixText.ToLower())
                                                     select n.Name)
                                                     .Union(from n in db.Drugs
                                                            where n.Id.ToString().ToLower().Contains(prefixText.ToLower())
                                                            select n.Id.ToString());

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
        }
    }
}