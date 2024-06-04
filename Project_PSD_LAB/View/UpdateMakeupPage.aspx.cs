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
    public partial class UpdateMakeupPage : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                String makeupId = Request.QueryString["id"];
                if (makeupId != null)
                {
                    Makeup makeup = MakeupController.getMakeupById(int.Parse(makeupId));
                    if (makeup != null)
                    {
                        NameTxt.Text = makeup.MakeupName;
                        PriceTxt.Text = makeup.MakeupPrice.ToString();
                        WeightTxt.Text = makeup.MakeupWeight.ToString();
                        TypeIDTxt.Text = makeup.MakeupTypeID.ToString();
                        BrandIDTxt.Text = makeup.MakeupBrandID.ToString();
                    }
                }
            }
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ManageMakeupPage.aspx");
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            String makeupId = Request.QueryString["id"]; ;
            Makeup makeup = MakeupController.getMakeupById(int.Parse(makeupId));
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

            MakeupController.updateMakeup(makeup, name, int.Parse(price), int.Parse(weight), int.Parse(typeId), int.Parse(brandId));
            Response.Redirect("~/View/ManageMakeupPage.aspx");
        }
    }
}