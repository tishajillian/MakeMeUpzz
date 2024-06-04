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
    public partial class UpdateMakeupTypePage : System.Web.UI.Page
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
                String makeupTypeId = Request.QueryString["id"];
                if (makeupTypeId != null)
                {
                    MakeupType makeupType = MakeupTypeController.getMakeupTypeById(int.Parse(makeupTypeId));
                    if (makeupType != null)
                    {
                        NameTxt.Text = makeupType.MakeupTypeName;
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
            String makeupTypeId = Request.QueryString["id"]; ;
            MakeupType makeupType = MakeupTypeController.getMakeupTypeById(int.Parse(makeupTypeId));
            String name = NameTxt.Text;
            Response<MakeupType> response = MakeupTypeController.checkMakeupType(name);
            if (response.IsSuccess)
            {
                MakeupTypeController.updateMakeupType(makeupType, name);
                Response.Redirect("~/View/ManageMakeupPage.aspx");
            }
            ErrorLbl.Text = response.Message.ToString();
        }
    }
}