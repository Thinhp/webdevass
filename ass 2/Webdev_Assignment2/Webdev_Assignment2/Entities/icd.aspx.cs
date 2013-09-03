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
    public partial class icd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Pop up all records in dropdown
            if (!Page.IsPostBack)
            {
                DataBaseServerDataContext db = new DataBaseServerDataContext();
                var thelist = from p in db.ICDChapters
                              select p.Name;

                ICDChapterDropDown.DataSource = thelist.ToArray();
                ICDChapterDropDown.DataBind();
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

            //join two table


            var searched = from p in db.ICDs
                            join g in db.ICDChapters
                            on p.ICDChapterId equals g.id
                           where p.Name.Contains(searchkey)
                           || p.Code.ToString().Contains(searchkey)
                           || g.id.ToString().Contains(searchkey)
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
                var name = NameTextBox.Text;
                var code = CodeBox.Text;

                //Get from dropdown box
                var chapter = ICDChapterDropDown.SelectedValue;
                var allId = from g in db.ICDChapters
                            select g;

                int targetId = 0;
                foreach (var n in allId)
                {
                    if (n.Name.Equals(chapter))
                    {
                        targetId = n.id;
                        break;
                    }
                }

                var insert = new ICD()
                {
                    Name = name,
                    Code = code,
                    ICDChapterId = targetId
                };

                db.ICDs.InsertOnSubmit(insert);
                db.SubmitChanges();
                GridView1.DataBind();

                //reset field
                NameTextBox.Text = "";
                CodeBox.Text = "";

                StringBuilder sb = new StringBuilder();
                sb.Append("toggle_visibility('SuccessBoxMessage');");

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "successicd", sb.ToString(), true);

            }

        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static string[] GetCompletionList(string prefixText)
        {
            DataBaseServerDataContext db = new DataBaseServerDataContext();
            var result = (from n in db.ICDs
                          where n.Code.ToString().ToLower().Contains(prefixText.ToLower())
                          select n.Code.ToString())
                         .Union(from n in db.ICDs
                                where n.Name.ToLower().Contains(prefixText.ToLower())
                                select n.Name)
                                .Union(from n in db.ICDChapters
                                       where n.id.ToString().Contains(prefixText.ToLower())
                                       select n.id.ToString())
                                       .Union(from n in db.ICDChapters
                                              where n.Name.ToLower().Contains(prefixText.ToLower())
                                              select n.Name);

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