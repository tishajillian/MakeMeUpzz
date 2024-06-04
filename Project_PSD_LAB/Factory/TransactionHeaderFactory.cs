using Project_PSD_LAB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_LAB.Factory
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader CreateTransactionHeader(int transactionID, int userID, DateTime transactionDate, String status)
        {
            TransactionHeader transactionHeader = new TransactionHeader()
            {
                TransactionID = transactionID,
                UserID = userID,
                TransactionDate = transactionDate,
                Status = status
            };
            return transactionHeader;
        }
    }
}