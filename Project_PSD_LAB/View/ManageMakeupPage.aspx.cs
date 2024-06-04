using Project_PSD_LAB.Controller;
using Project_PSD_LAB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_PSD_LAB.View
{
    public partial class ManageMakeupPage : System.Web.UI.Page
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
                MakeupListGV.DataSource = MakeupController.getAllMakeup();
                MakeupListGV.DataBind();
                MakeupTypeListGV.DataSource = MakeupTypeController.getAllMakeupType();
                MakeupTypeListGV.DataBind();
                MakeupBrandListGV.DataSource = MakeupBrandController.getAllMakeupBrand();
                MakeupBrandListGV.DataBind();
            }
        }
        protected void MakeupListGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String MakeupId = MakeupListGV.DataKeys[e.RowIndex].Value.ToString();
            Response.Redirect("~/View/UpdateMakeupPage.aspx?id=" + MakeupId);
        }

        protected void MakeupListGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int MakeupId = Convert.ToInt32(MakeupListGV.DataKeys[e.RowIndex].Value);
            Makeup makeup = MakeupController.getMakeupById(MakeupId);
            MakeupController.removeMakeup(makeup);
            Response.Redirect("~/View/ManageMakeupPage.aspx");
        }
        protected void MakeupTypeListGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String MakeupTypeId = MakeupTypeListGV.DataKeys[e.RowIndex].Value.ToString();
            Response.Redirect("~/View/UpdateMakeupTypePage.aspx?id=" + MakeupTypeId);
        }

        protected void MakeupTypeListGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int MakeupTypeId = Convert.ToInt32(MakeupTypeListGV.DataKeys[e.RowIndex].Value);
            MakeupType makeupType = MakeupTypeController.getMakeupTypeById(MakeupTypeId);
            MakeupTypeController.removeMakeupType(makeupType);
            Response.Redirect("~/View/ManageMakeupPage.aspx");
        }
        protected void MakeupBrandListGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string makeupBrandId = MakeupBrandListGV.DataKeys[e.RowIndex].Value.ToString();
            Response.Redirect("~/View/UpdateMakeupBrandPage.aspx?id=" + makeupBrandId);
        }
        protected void MakeupBrandListGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int makeupBrandId = Convert.ToInt32(MakeupBrandListGV.DataKeys[e.RowIndex].Value);
            MakeupBrand makeupBrand = MakeupBrandController.getMakeupBrandById(makeupBrandId);
            MakeupBrandController.removeMakeupBrand(makeupBrand);
            Response.Redirect("~/View/ManageMakeupPage.aspx");
        }

        protected void InsertMakeupBrandBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/InsertMakeupBrandPage.aspx");
        }

        protected void InsertMakeupTypeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/InsertMakeupTypePage.aspx");
        }

        protected void InsertMakeupBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/InsertMakeupPage.aspx");
        }
    }
}