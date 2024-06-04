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
    public partial class ProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User user = UserController.getUserBySessionCookie();

                if(user != null)
                {
                    UsernameTxt.Text = user.Username;
                    EmailTxt.Text = user.UserEmail;
                    GenderRBList.Text = user.UserGender;
                    DOBTxt.Text = Convert.ToDateTime(user.UserDOB).ToString("yyyy-MM-dd");
                }
            }
        }
        protected void EditBtn_Click(object sender, EventArgs e)
        {
            UsernameTxt.Enabled = true;
            EmailTxt.Enabled = true;
            GenderRBList.Enabled = true;
            DOBTxt.Enabled = true;
            UpdateProfileBtn.Visible = true;
            EditBtn.Visible = false;
            CancelBtn.Visible = true;
        }
        protected void UpdateProfileBtn_Click(object sender, EventArgs e)
        {
            User user = UserController.getUserBySessionCookie();
            String username = UsernameTxt.Text;
            String email = EmailTxt.Text;
            String gender = GenderRBList.Text;
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

            if (user != null)
            {
                Response<User> response = UserController.checkUpdateProfile(user, username, email, gender, DateOfBirth);
                if(response.IsSuccess)
                {
                    UserController.updateProfile(user, username, email, gender, DateOfBirth);
                    Response.Redirect("~/View/ProfilePage.aspx");
                }
                ErrorLbl.Text = response.Message.ToString();
            }
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ProfilePage.aspx");
        }

        protected void UpdatePasswordBtn_Click(object sender, EventArgs e)
        {
            User user = UserController.getUserBySessionCookie();
            String oldPassword = OldPasswordTxt.Text;
            String newPassword = NewPasswordTxt.Text;

            if (user != null)
            {
                Response<User> response = UserController.checkUpdatePassword(user, oldPassword, newPassword);
                if (response.IsSuccess)
                {
                    UserController.updatePassword(user, newPassword);
                    Response.Redirect("~/View/ProfilePage.aspx");
                }
                PasswordErrorLbl.Text = response.Message.ToString();
            }
        }
    }
}