using Project_PSD_LAB.Factory;
using Project_PSD_LAB.Model;
using Project_PSD_LAB.Modules;
using Project_PSD_LAB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_LAB.Handler
{
    public class TransactionHeaderHandler
    {
        public static int generateId()
        {
            TransactionHeader transactionHeader = TransactionHeaderRepository.getLastTransaction();
            if(transactionHeader == null)
            {
                return 1;
            }
            int lastId = transactionHeader.TransactionID;
            lastId++;
            return lastId;
        }
        public static Response<TransactionHeader> addTransaction(int userId, DateTime dateTime, String status, List<Cart> cartItems)
        {
            TransactionHeader transactionHeader = TransactionHeaderFactory.CreateTransactionHeader(generateId(), userId, dateTime, status);
            TransactionHeaderRepository.createTransactionHeader(transactionHeader);

            foreach (var cartItem in cartItems)
            {
                TransactionDetail transactionDetail = TransactionDetailFactory.CreateTransactionDetail(transactionHeader.TransactionID, cartItem.MakeupID, cartItem.Quantity);
                TransactionDetailRepository.createTransactionDetail(transactionDetail);
            }

            return new Response<TransactionHeader>
            {
                Message = "Success",
                IsSuccess = true,
                payload = transactionHeader
            };
        }
        public static List<TransactionHeader> getAllTransactionHeaders()
        {
            return TransactionHeaderRepository.getAllTransactionHeaders();
        }
        public static List<TransactionHeader> getAllTransactionHeadersOfAnUser(int userId)
        {
            return TransactionHeaderRepository.getAllTransactionHeadersOfAnUser(userId);
        }
        public static List<TransactionHeader> getAllUnhandledTransaction()
        {
            return TransactionHeaderRepository.getAllUnhandledTransaction();
        }
        public static TransactionHeader getTransactionHeaderById(int id)
        {
            return TransactionHeaderRepository.getTransactionHeaderById(id);
        }
        public static Response<TransactionHeader> updateStatus(TransactionHeader transactionHeader)
        {
            TransactionHeaderRepository.updateStatus(transactionHeader);
            return new Response<TransactionHeader>
            {
                Message = "Success",
                IsSuccess = true,
                payload = transactionHeader
            };
        }
    }
}