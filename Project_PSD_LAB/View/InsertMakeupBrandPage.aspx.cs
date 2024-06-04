using Project_PSD_LAB.Controller;
using Project_PSD_LAB.Model;
using Project_PSD_LAB.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_PSD_LAB.View
{
    public partial class InsertMakeupBrandPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserController.isUserLoggedIn())
            {
                Response.Redirect("~/View/LoginPage.aspx");
                return;
            }

            if (!UserController.isUserAdmin())
            {
                Response.Redirect($"~/View/Unauthorized.aspx");
                return;
            }
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            String name = NameTxt.Text;
            String rating = RatingTxt.Text;
            Response<MakeupBrand> response = MakeupBrandController.checkMakeupBrand(name, rating);
            if(response.IsSuccess)
            {
                MakeupBrandController.addMakeupBrand(name, int.Parse(rating));
                Response.Redirect("~/View/InsertMakeupBrandPage.aspx");
            }
            ErrorLbl.Text = response.Message.ToString();
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ManageMakeupPage.aspx");
        }
    }
}