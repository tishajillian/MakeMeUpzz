using Project_PSD_LAB.Controller;
using Project_PSD_LAB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_PSD_LAB.View
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (UserController.isUserAdmin())
                {
                    UserListContainer.Visible = true;
                    UserListGV.DataSource = UserController.getAllUser();
                    UserListGV.DataBind();
                }
                else
                {
                    UserListContainer.Visible = false;
                    UsernameLbl.Visible = true;
                    UserRoleLbl.Visible = true;
                    User user = UserController.getUserBySessionCookie();
                    if (user != null)
                    {
                        UsernameLbl.Text = "Hello, <span style='font-weight:bold;'>" + user.Username.ToString() + "</span>!";
                        UserRoleLbl.Text = "Your role is <span style='font-weight:bold;'>" + user.UserRole.ToString() + "</span>";
                    }
                }                  
            }

        }
    }
}