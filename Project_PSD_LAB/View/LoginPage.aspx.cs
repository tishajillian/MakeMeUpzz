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
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserController.isUserLoggedIn())
            {
                Response.Redirect("~/View/HomePage.aspx");
            }
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/RegisterPage.aspx");
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            String username = UsernameTxt.Text;
            String password = PasswordTxt.Text;
            Response<User> response = UserController.doLogin(username, password);
            if (response.IsSuccess)
            {
                ErrorLbl.Text = response.Message;
                User user = response.payload;
                Session["user"] = user;
                string userRole = user.UserRole;
                Session["userRole"] = userRole;
                if (RememberMeCbx.Checked)
                {
                    HttpCookie cookie = new HttpCookie("user_cookie");
                    cookie.Value = username;
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                }
                Response.Redirect("~/View/HomePage.aspx");
            }
            ErrorLbl.Text = response.Message;
        }
    }
}