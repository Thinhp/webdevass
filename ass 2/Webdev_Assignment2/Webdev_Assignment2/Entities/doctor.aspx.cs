using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            var searched = from p in db.Doctors
                           where p.Name.Contains(searchkey)
                           || p.Licensenumber.Contains(searchkey)
                           || p.Id.ToString().Contains(searchkey)
                           || p.Address.Contains(searchkey)
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
                var dob = DobTextBox.Text;
                var license = LicenseTextBox.Text;
                var address = AddressTextBox.Text;

                var insert = new Doctor()
                {
                    Name = name,
                    Dob = dob,
                    Licensenumber = license,
                    Address = address
                };

                db.Doctors.InsertOnSubmit(insert);
                db.SubmitChanges();
                GridView1.DataBind();

                //reset field
                NameTextBox.Text = "";
                DobTextBox.Text = "";
                LicenseTextBox.Text = "";
                AddressTextBox.Text = "";

                StringBuilder sb = new StringBuilder();
                sb.Append("toggle_visibility('SuccessBoxMessage');");

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "success", sb.ToString(), true);
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "AnUniqueKey", "toggle_visibility('FailBoxMessage');", true);
            }

        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static string[] GetCompletionList(string prefixText)
        {
            DataBaseServerDataContext db = new DataBaseServerDataContext();
            var result = (from n in db.Doctors
                          where n.Id.ToString().ToLower().Contains(prefixText.ToLower())
                          select n.Id.ToString())
                         .Union(from n in db.Doctors
                                where n.Name.ToLower().Contains(prefixText.ToLower())
                                select n.Name)
                                .Union(from n in db.Doctors
                                       where n.Dob.Contains(prefixText.ToLower())
                                       select n.Dob)
                                       .Union(from n in db.Doctors
                                              where n.Address.ToLower().Contains(prefixText.ToLower())
                                              select n.Address)
                                              .Union(from n in db.Doctors
                                                     where n.Licensenumber.ToLower().Contains(prefixText.ToLower())
                                                     select n.Licensenumber);

            return result.ToArray();
        }

        protected void DobCalendar_SelectionChanged(object sender, EventArgs e)
        {
            string enteredDate = DobCalendar.SelectedDate.Day + "/" +
                DobCalendar.SelectedDate.Month + "/" + DobCalendar.SelectedDate.Year;
            DobTextBox.Text = enteredDate;
        }

    }
}