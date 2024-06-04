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
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/LoginPage.aspx");
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            String username = UsernameTxt.Text;
            String email = EmailTxt.Text;
            String gender = GenderRBList.Text;
            String password = PasswordTxt.Text;
            String confPassword = ConfirmationPasswordTxt.Text;
            String DOB = DOBTxt.Text;
            DateTime DateOfBirth;
            if (DateTime.TryParse(DOB, out DateOfBirth))
            {
                DateOfBirth = DateTime.Parse(DOB);
            }
            else
            {
                ErrorLbl.Text = "Date Of Birth must be filled!";
            }
            Response<User> response = UserController.checkRegister(username, email, gender, password, confPassword, DateOfBirth);
            if (response.IsSuccess)
            {
                UserController.doRegister(username, email, gender, password, DateOfBirth);
                Response.Redirect("~/View/LoginPage.aspx");
            }
            ErrorLbl.Text = response.Message;
        }
    }
}