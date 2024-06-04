using Project_PSD_LAB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_PSD_LAB.View
{
    public partial class NavBar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Project_PSD_LAB.Controller.UserController.isUserLoggedIn())
                {
                    if (Project_PSD_LAB.Controller.UserController.isUserAdmin())
                    {
                        HomeBtn.Visible = true;
                        ManageMakeupBtn.Visible = true;
                        OrderQueueBtn.Visible = true;
                        TransactionReportBtn.Visible = true;
                        OrderMakeupBtn.Visible = false;
                        HistoryBtn.Visible = true;
                    }
                    else
                    {
                        HomeBtn.Visible = true;
                        ManageMakeupBtn.Visible = false;
                        OrderQueueBtn.Visible = false;
                        TransactionReportBtn.Visible = false;
                        OrderMakeupBtn.Visible = true;
                        HistoryBtn.Visible = true;
                    }
                }
                else
                {
                    Response.Redirect("~/View/LoginPage.aspx");
                }
            }
        }               
        
        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Remove("user");
            Session.Remove("userRole");

            HttpCookie cookie = Request.Cookies["user_cookie"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }

            Response.Redirect("~/View/LoginPage.aspx");
        }

        protected void OrderMakeupBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/OrderMakeupPage.aspx");
        }

        protected void ProfileBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ProfilePage.aspx");
        }

        protected void HistoryBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/HistoryPage.aspx");
        }

        protected void ManageMakeupBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ManageMakeupPage.aspx");
        }

        protected void HomeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/HomePage.aspx");
        }

        protected void OrderQueueBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/OrderQueuePage.aspx");
        }

        protected void TransactionReportBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/TransactionReportPage.aspx");
        }
    }
}
