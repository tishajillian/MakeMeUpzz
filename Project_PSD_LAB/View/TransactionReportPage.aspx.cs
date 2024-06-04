using Project_PSD_LAB.Controller;
using Project_PSD_LAB.Dataset;
using Project_PSD_LAB.Model;
using Project_PSD_LAB.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_PSD_LAB.View
{
    public partial class TransactionReportPage : System.Web.UI.Page
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
            CrystalReport3 report = new CrystalReport3();
            DataSet1 dataSet = getDataSet(TransactionHeaderController.getAllTransactionHeaders());

            if (dataSet.Tables.Count > 0)
            {
                CalculateGrandTotals(dataSet.Tables["TransactionHeaders"]);
                report.SetDataSource(dataSet);
                CrystalReportViewer1.ReportSource = report;
            }
            else
            {
                DescLbl.Visible = true;
            }
        }
        private void CalculateGrandTotals(DataTable transactionHeaders)
        {
            foreach (DataRow headerRow in transactionHeaders.Rows)
            {
                decimal grandTotal = CalculateGrandTotalForHeader(headerRow);
                headerRow["GrandTotal"] = grandTotal;
            }
        }
        private decimal CalculateGrandTotalForHeader(DataRow headerRow)
        {
            decimal grandTotal = 0;
            foreach (DataRow detailRow in headerRow.GetChildRows("TransactionHeaders_TransactionDetails"))
            {
                grandTotal += Convert.ToDecimal(detailRow["Subtotal"]);
            }
            return grandTotal;
        }
        private DataSet1 getDataSet(List<TransactionHeader> transactionHeaders)
        {
            DataSet1 dataSet = new DataSet1();
            var header = dataSet.TransactionHeaders;
            var detail = dataSet.TransactionDetails;

            foreach (TransactionHeader t in transactionHeaders)
            {
                var headerRow = header.NewRow();
                headerRow["TransactionID"] = t.TransactionID;
                headerRow["UserID"] = t.UserID + " " + "[" + t.User.Username + "]";
                headerRow["TransactionDate"] = t.TransactionDate;
                headerRow["Status"] = t.Status;
                header.Rows.Add(headerRow);

                foreach (TransactionDetail d in t.TransactionDetails)
                {
                    var detailRow = detail.NewRow();
                    detailRow["TransactionID"] = d.TransactionID;
                    detailRow["MakeupID"] = d.MakeupID + " " + "[" + d.Makeup.MakeupName + "]";
                    detailRow["Quantity"] = d.Quantity;
                    detailRow["Subtotal"] = d.Quantity * d.Makeup.MakeupPrice;
                    detail.Rows.Add(detailRow);
                }
            }

            return dataSet;
        }
    }
}