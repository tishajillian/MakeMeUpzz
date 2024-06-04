using Project_PSD_LAB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_LAB.Repository
{
    public class TransactionHeaderRepository
    {
        private static Database1Entities1 db = new Database1Entities1 ();
        public static void createTransactionHeader(TransactionHeader transactionHeader)
        {
            db.TransactionHeaders.Add(transactionHeader);
            db.SaveChanges();
        }
        public static TransactionHeader getLastTransaction()
        {
            return db.TransactionHeaders.ToList().LastOrDefault();
        }
        public static List<TransactionHeader> getAllTransactionHeaders()
        {
            return (from x in db.TransactionHeaders
                    select x).ToList();
        }
        public static List<TransactionHeader> getAllTransactionHeadersOfAnUser(int userId)
        {
            return (from x in db.TransactionHeaders
                    where x.UserID == userId
                    select x).ToList();
        }
        public static List<TransactionHeader> getAllUnhandledTransaction()
        {
            return (from x in db.TransactionHeaders
                    where x.Status.Equals("Unhandled")
                    select x).ToList();
        }
        public static TransactionHeader getTransactionHeaderById(int id)
        {
            return (from x in db.TransactionHeaders
                    where x.TransactionID == id
                    select x).FirstOrDefault();
        }
        public static void updateStatus(TransactionHeader transactionHeader)
        {
            transactionHeader.Status = "Handled";
            db.SaveChanges();
        }
    }
}