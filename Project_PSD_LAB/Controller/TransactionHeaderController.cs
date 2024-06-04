using Project_PSD_LAB.Handler;
using Project_PSD_LAB.Model;
using Project_PSD_LAB.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_LAB.Controller
{
    public class TransactionHeaderController
    {
        public static Response<TransactionHeader> addTransaction(int userId, DateTime dateTime, String status, List<Cart> cartItems)
        {
            Response<TransactionHeader> response = TransactionHeaderHandler.addTransaction(userId, dateTime, status, cartItems);
            return response;
        }
        public static List<TransactionHeader> getAllTransactionHeaders()
        {
            return TransactionHeaderHandler.getAllTransactionHeaders();
        }
        public static List<TransactionHeader> getAllTransactionHeadersOfAnUser(int userId)
        {
            return TransactionHeaderHandler.getAllTransactionHeadersOfAnUser(userId);
        }
        public static List<TransactionHeader> getAllUnhandledTransaction()
        {
            return TransactionHeaderHandler.getAllUnhandledTransaction();
        }
        public static TransactionHeader getTransactionHeaderById(int id)
        {
            return TransactionHeaderHandler.getTransactionHeaderById(id);
        }
        public static Response<TransactionHeader> updateStatus(TransactionHeader transactionHeader)
        {
            Response<TransactionHeader> response = TransactionHeaderHandler.updateStatus(transactionHeader);
            return response;
        }
    }
}