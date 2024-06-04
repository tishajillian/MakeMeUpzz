using Project_PSD_LAB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Project_PSD_LAB.Repository
{
    public class MakeupRepository
    {
        private static Database1Entities1 db = new Database1Entities1();

        public static Makeup getMakeupByName(String makeupName)
        {
            return (from x in db.Makeups
                    where x.MakeupName.Equals(makeupName)
                    select x).FirstOrDefault();
        }
        public static Makeup getLastMakeup()
        {
            return db.Makeups.ToList().LastOrDefault();
        }
        public static void createMakeup(Makeup makeup)
        {
            db.Makeups.Add(makeup);
            db.SaveChanges();
        }
        public static List<Makeup> getAllMakeup()
        {
            return (from x in db.Makeups select x).ToList();
        }
        public static Makeup getMakeupById(int id)
        {
            return (from x in db.Makeups
                    where x.MakeupID == id
                    select x).FirstOrDefault();
        }
        public static void addMakeup(Makeup makeup)
        {
            db.Makeups.Add(makeup);
            db.SaveChanges();
        }
        public static void updateMakeup(Makeup makeup, String newName,
            int newPrice, int newWeight, int typeId, int brandId)
        {
            makeup.MakeupName = newName;
            makeup.MakeupPrice = newPrice;
            makeup.MakeupWeight = newWeight;
            makeup.MakeupTypeID = typeId;
            makeup.MakeupBrandID = brandId;
            db.SaveChanges();
        }
        public static void removeMakeup(Makeup makeup)
        {
            db.Makeups.Remove(makeup);
            db.SaveChanges();
        }
    }
}