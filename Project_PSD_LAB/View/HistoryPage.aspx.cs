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
    public partial class HistoryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(UserController.isUserAdmin())
                {
                    List<TransactionHeader> data = TransactionHeaderController.getAllTransactionHeaders();
                    if(data.Count != 0)
                    {
                        TransactionListGV.DataSource = data;
                        TransactionListGV.DataBind();
                    }
                    else
                    {
                        StatusLbl.Visible = true;
                    }

                }
                else
                {
                    User user = UserController.getUserBySessionCookie();
                    if(user != null)
                    {
                        List<TransactionHeader> data = TransactionHeaderController.getAllTransactionHeadersOfAnUser(user.UserID);
                        if (data.Count != 0)
                        {
                            TransactionListGV.DataSource = data;
                            TransactionListGV.DataBind();
                        }
                        else
                        {
                            StatusLbl.Visible = true;
                        }

                    }
                }
            }
        }
        protected void TransactionListGV_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            String TransactionId = TransactionListGV.DataKeys[e.NewSelectedIndex]["TransactionID"].ToString();
            Response.Redirect("TransactionDetailPage.aspx?id=" + TransactionId);
        }
    }
}