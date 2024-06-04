using Project_PSD_LAB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_LAB.Factory
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail CreateTransactionDetail (int transactionID, int makeupID, int quantity)
        {
            TransactionDetail transactionDetail = new TransactionDetail()
            {
                TransactionID = transactionID,
                MakeupID = makeupID,
                Quantity = quantity
            };
            return transactionDetail;
        }
    }
}