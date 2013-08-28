using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webdev_Assignment2
{
    public partial class index : System.Web.UI.Page
    {
        DataBaseServerDataContext db;

        protected void Page_Load(object sender, EventArgs e)
        {
            db = new DataBaseServerDataContext();

        }

        protected void LoginForm1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            //Get response
            var response = base.Response;

            //Create sessions to store
            Session["Username"] = "";
            Session["Password"] = "";

            //Linq command
            var allUsers = from p in db.Users
                           select p;

            //Check username, password and role
            if (!LoginForm1.UserName.Equals("") && !LoginForm1.Password.Equals(""))
            {
                foreach (var user in allUsers)
                {
                    bool validUser = false;
                    bool validPass = false;

                    if (user.UserName.Equals(LoginForm1.UserName))
                    {
                        Session["Username"] = user.UserName;
                        validUser = true;
                    }

                    if (user.Password.Equals(LoginForm1.Password))
                    {
                        Session["Password"] = user.Password;
                        validPass = true;
                    }

                    if (validUser && validPass)
                    {
                        Session["Role"] = user.Role;
                        break;
                    }
                }
            }

            //If matched and not empty -> direct to home.aspx
            if (!Session["Username"].Equals("") && !Session["Password"].Equals(""))
            {
                response.Redirect("http://localhost:37730/home.aspx", false);
            }
        }
    }
}