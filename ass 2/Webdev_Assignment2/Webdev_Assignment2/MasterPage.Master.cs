using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webdev_Assignment2
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();
        }

        
        protected void LogoutLinkButton_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Response.Redirect("~/index.aspx",false);
        }

        protected void HomeButton_Click(object sender, EventArgs e)
        {
            var response = base.Response;
            response.Redirect("~/home.aspx", false);
        }

        protected void AboutButton_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            var response = base.Response;
            response.Redirect("~/Entities/doctor.aspx", false);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            var response = base.Response;
            response.Redirect("~/Entities/patient.aspx", false);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            var response = base.Response;
            response.Redirect("~/Entities/hospital.aspx", false);
        }

        protected void Drug_Group_Click(object sender, EventArgs e)
        {
            var response = base.Response;
            response.Redirect("~/Entities/druggroup.aspx", false);
        }

        protected void Drug_Click(object sender, EventArgs e)
        {
            var response = base.Response;
            response.Redirect("~/Entities/drug.aspx", false);
        }

        protected void Icd_Chapter_Click(object sender, EventArgs e)
        {
            var response = base.Response;
            response.Redirect("~/Entities/icdchapter.aspx", false);
        }

        protected void Icd_Click(object sender, EventArgs e)
        {
            var response = base.Response;
            response.Redirect("~/Entities/icd.aspx", false);
        }

        protected void Medical_Service_Click(object sender, EventArgs e)
        {
            var response = base.Response;
            response.Redirect("~/Entities/medicalservice.aspx", false);
        }

        protected void Medical_Service_Group_Click(object sender, EventArgs e)
        {
            var response = base.Response;
            response.Redirect("~/Entities/medicalservicegroup.aspx", false);
        }

        protected void Prescription_Info_Click(object sender, EventArgs e)
        {
            var response = base.Response;
            response.Redirect("~/Entities/prescriptioninfo.aspx", false);
        }

        protected void Prescription_Click(object sender, EventArgs e)
        {
            var response = base.Response;
            response.Redirect("~/Entities/prescription.aspx", false);
        }
    }
}