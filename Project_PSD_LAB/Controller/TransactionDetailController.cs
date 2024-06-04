using Project_PSD_LAB.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_LAB.Controller
{
    public class TransactionDetailController
    {
        public static List<object> showDetail(int transactionId)
        {
            return TransactionDetailHandler.showDetail(transactionId);
        }
    }
}