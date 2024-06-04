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
    public partial class OrderQueuePage : System.Web.UI.Page
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
                List<TransactionHeader> transactionHeaders = TransactionHeaderController.getAllUnhandledTransaction();
                if(transactionHeaders.Count == 0)
                {
                    StatusLbl.Text = "There is no order at the moment!";
                }
                else
                {
                    TransactionListGV.DataSource = transactionHeaders;
                    TransactionListGV.DataBind();
                }
            }
        }
        protected void TransactionListGV_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            String id = TransactionListGV.DataKeys[e.NewSelectedIndex]["TransactionID"].ToString();
            int transactionId = int.Parse(id);
            TransactionHeader transactionHeader = TransactionHeaderController.getTransactionHeaderById(transactionId);
            TransactionHeaderController.updateStatus(transactionHeader);
            Response.Redirect("~/View/OrderQueuePage.aspx");
        }
    }
}