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
    public partial class prescription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataBaseServerDataContext db = new DataBaseServerDataContext();
                var doctorlist = from p in db.Doctors
                              select p.Name;

                var presidlist = from g in db.PrescriptionDetails
                                 select g.Id;

                DoctorTextBox.DataSource = doctorlist.ToArray();
                DoctorTextBox.DataBind();

                PresDropDown.DataSource = presidlist.ToArray();
                PresDropDown.DataBind();
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

            var searched = from p in db.Prescriptions
                           join g in db.Doctors
                           on p.PrescribedDoctor equals g.Id
                           where p.id.ToString().Contains(searchkey)
                           || p.Date.Contains(searchkey)
                           || g.Name.ToString().Contains(searchkey)
                           select p;

            e.Result = searched;
        }

        protected void InsertButton_Click(object sender, EventArgs e)
        {
            //Check validation
            if (IsValid)
            {
                DataBaseServerDataContext db = new DataBaseServerDataContext();
                var date = DateTextBox.Text;
                var doctor = DoctorTextBox.SelectedValue;
                var presid = PresDropDown.SelectedValue;

                //Get Dropbox list menu item and check with id
                var allId = from g in db.Doctors
                            select g;

                int targetId = 0;
                foreach (var n in allId)
                {
                    if (n.Name.Equals(doctor))
                    {
                        targetId = n.Id;
                        break;
                    }
                }

                var insert = new Prescription()
                {
                    Date = date,
                    PrescribedDoctor = targetId,
                    PrescriptionDetailsId = Int32.Parse(presid)
                };

                db.Prescriptions.InsertOnSubmit(insert);
                db.SubmitChanges();
                GridView1.DataBind();

                //reset field
                DateTextBox.Text = "";

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
            var result = (from n in db.Prescriptions
                          where n.id.ToString().ToLower().Contains(prefixText.ToLower())
                          select n.id.ToString())
                         .Union(from n in db.Prescriptions
                                where n.Date.ToLower().Contains(prefixText.ToLower())
                                select n.Date)
                                .Union(from n in db.Doctors
                                       where n.Name.Contains(prefixText.ToLower())
                                       select n.Name);

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

            //No inserting datetime
            DateTextBox.Attributes.Add("readonly", "readly");

            if (GridView1.EditIndex != -1)
            {
                int index = GridView1.EditIndex;
                TextBox text = GridView1.Rows[index].FindControl("DateCol") as TextBox;
                text.Attributes.Add("readonly", "readonly");
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}