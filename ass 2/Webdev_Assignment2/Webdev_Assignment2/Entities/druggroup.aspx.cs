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
    public partial class druggroup : System.Web.UI.Page
    {
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

            var searched = from p in db.DrugGroups
                           where p.GroupName.Contains(searchkey)
                           || p.DrugGroupId.ToString().Contains(searchkey)
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

                var insert = new DrugGroup()
                {
                    GroupName = name,

                };

                db.DrugGroups.InsertOnSubmit(insert);
                db.SubmitChanges();
                GridView1.DataBind();

                //reset field
                NameTextBox.Text = "";

                StringBuilder sb = new StringBuilder();
                sb.Append("toggle_visibility('SuccessBoxMessage');");

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "successdruggroup", sb.ToString(), true);

            }

        }

        //Return an array of completed list to search
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static string[] GetCompletionList(string prefixText)
        {

            DataBaseServerDataContext db = new DataBaseServerDataContext();
            var result = (from n in db.DrugGroups
                          where n.DrugGroupId.ToString().ToLower().Contains(prefixText.ToLower())
                          select n.DrugGroupId.ToString())
                         .Union(from n in db.DrugGroups
                                where n.GroupName.ToLower().Contains(prefixText.ToLower())
                                select n.GroupName);

            return result.ToArray();
        }

        // Check user's role to hide edit and delete field
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

        //Check if druggroup existed
        protected void DrugGroup_Existed_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //Get Linq command from server
            DataBaseServerDataContext db = new DataBaseServerDataContext();
            var lin = from p in db.DrugGroups
                      select p.GroupName;

            foreach (var g in lin)
            {
                if (g.Equals(NameTextBox.Text))
                {
                    args.IsValid = false;
                    return;
                }
            }

            args.IsValid = true;

        }

        protected void DrugGroup_Existed_UpdateValidate(object source, ServerValidateEventArgs args)
        {
            //Get Linq command from server
            DataBaseServerDataContext db = new DataBaseServerDataContext();
            var lin = from p in db.DrugGroups
                      select p.GroupName;

            int index = GridView1.EditIndex;
            TextBox text = GridView1.Rows[index].FindControl("EditItemGroupName") as TextBox;

            foreach (var g in lin)
            {
                if (g.Equals(text.Text))
                {
                    args.IsValid = false;
                    return;
                }
            }

            args.IsValid = true;
        }



    }
}