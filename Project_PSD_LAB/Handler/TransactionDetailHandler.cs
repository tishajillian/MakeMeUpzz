using Project_PSD_LAB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_LAB.Handler
{
    public class TransactionDetailHandler
    {
        public static List<object> showDetail(int transactionId)
        {
            return TransactionDetailRepository.showDetail(transactionId);
        }
    }
}