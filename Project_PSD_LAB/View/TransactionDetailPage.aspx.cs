using Project_PSD_LAB.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_PSD_LAB.View
{
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String transactionId = Request.QueryString["id"];
                TransactionDetailGV.DataSource = TransactionDetailController.showDetail(int.Parse(transactionId));
                TransactionDetailGV.DataBind();
            }
        }
    }
}