using Project_PSD_LAB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_LAB.Repository
{
    public class MakeupTypeRepository
    {
        private static Database1Entities1 db = new Database1Entities1 ();
        public static List<MakeupType> getAllMakeupType()
        {
            return (from x in db.MakeupTypes
                    select x).ToList();
        }
        public static MakeupType getMakeupTypeById(int id)
        {
            return (from x in db.MakeupTypes
                    where x.MakeupTypeID == id
                    select x).FirstOrDefault();
        }
        public static MakeupType getLastMakeupType()
        {
            return db.MakeupTypes.ToList().LastOrDefault();
        }
        public static void addMakeupType(MakeupType makeupType)
        {
            db.MakeupTypes.Add(makeupType);
            db.SaveChanges();
        }
        public static void updateMakeupType(MakeupType makeupType, String newName)
        {
            makeupType.MakeupTypeName = newName;
            db.SaveChanges();
        }
        public static void removeMakeupType(MakeupType makeupType)
        {
            db.MakeupTypes.Remove(makeupType);
            db.SaveChanges();
        }
        public static MakeupType isThisMakeupTypeExists (int id)
        {
            return (from x in db.MakeupTypes
                    where x.MakeupTypeID == id
                    select x)?.FirstOrDefault();
        }
    }
}