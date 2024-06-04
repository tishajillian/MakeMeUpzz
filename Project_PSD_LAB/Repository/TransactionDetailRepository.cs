using Project_PSD_LAB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_LAB.Repository
{
    public class TransactionDetailRepository
    {
        private static Database1Entities1 db = new Database1Entities1 ();
        public static void createTransactionDetail(TransactionDetail transactionDetail)
        {
            db.TransactionDetails.Add(transactionDetail);
            db.SaveChanges();
        }
        public static List<object> showDetail(int transactionId)
        {
            var td = (from x in db.TransactionDetails
                             join Makeup in db.Makeups on x.MakeupID equals Makeup.MakeupID
                             join MakeupBrand in db.MakeupBrands on Makeup.MakeupBrandID equals MakeupBrand.MakeupBrandID
                             join MakeupType in db.MakeupTypes on Makeup.MakeupTypeID equals MakeupType.MakeupTypeID
                             where x.TransactionID == transactionId
                             select new
                             {
                                 TransactionID = x.TransactionID,
                                 MakeupID = Makeup.MakeupID,
                                 MakeupName = Makeup.MakeupName,
                                 MakeupPrice = Makeup.MakeupPrice,
                                 MakeupWeight = Makeup.MakeupWeight,
                                 MakeupTypeName = MakeupType.MakeupTypeName,
                                 MakeupBrandName = MakeupBrand.MakeupBrandName,
                                 Quantity = x.Quantity,
                                 Total = x.Quantity * Makeup.MakeupPrice
                             }).ToList<object>();
            return td;
        }
    }
}