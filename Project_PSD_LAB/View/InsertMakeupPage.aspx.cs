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
    public partial class InsertMakeupPage : System.Web.UI.Page
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

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ManageMakeupPage.aspx");
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            String name = NameTxt.Text;
            String price = PriceTxt.Text;
            String weight = WeightTxt.Text;
            String typeId = TypeIDTxt.Text;
            String brandId = BrandIDTxt.Text;
            Response<Makeup> responseMakeup = MakeupController.checkMakeup(name, price, weight, typeId, brandId);
            if (!responseMakeup.IsSuccess)
            {
                ErrorLbl.Text = responseMakeup.Message.ToString();
                return;
            }
            Response<Makeup> responseTypeBrand = MakeupController.checkMakeupTypeBrand(int.Parse(typeId), int.Parse(brandId));
            if (!responseTypeBrand.IsSuccess)
            {
                ErrorLbl.Text = responseTypeBrand.Message.ToString();
                return;
            }
            MakeupController.addMakeup(name, int.Parse(price), int.Parse(weight), int.Parse(typeId), int.Parse(brandId));
            Response.Redirect("~/View/InsertMakeupPage.aspx");
        }
    }
}