using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_PSD_LAB.View
{
    public partial class Unauthorized : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/HomePage.aspx");
        }
    }
}