using Project_PSD_LAB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_LAB.Repository
{
    public class MakeupBrandRepository
    {
        private static Database1Entities1 db = new Database1Entities1();
        public static void addMakeupBrand(MakeupBrand makeupBrand)
        {
            db.MakeupBrands.Add(makeupBrand);
            db.SaveChanges();
        }
        public static List<MakeupBrand> getAllMakeupBrands()
        {
            return (from x in db.MakeupBrands
                    orderby x.MakeupBrandRating descending
                    select x).ToList();
        }
        public static MakeupBrand getLastMakeupBrand()
        {
            return db.MakeupBrands.ToList().LastOrDefault();
        }
        public static MakeupBrand getMakeupBrandById(int id)
        {
            return (from x in db.MakeupBrands
                    where x.MakeupBrandID == id
                    select x).FirstOrDefault();
        }
        public static void updateMakeupBrand(MakeupBrand makeupBrand, String newName, int newRating)
        {
            makeupBrand.MakeupBrandName = newName;
            makeupBrand.MakeupBrandRating = newRating;
            db.SaveChanges();
        }
        public static void removeMakeupBrand(MakeupBrand makeupBrand)
        {
            db.MakeupBrands.Remove(makeupBrand);
            db.SaveChanges();
        }
        public static MakeupBrand isThisMakeupBrandExists(int id)
        {
            return (from x in db.MakeupBrands
                    where x.MakeupBrandID == id
                    select x).FirstOrDefault();
        }
    }
}