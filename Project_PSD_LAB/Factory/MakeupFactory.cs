using Project_PSD_LAB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_LAB.Factory
{
    public class MakeupFactory
    {
        public static Makeup CreateMakeup(int makeupID, String makeupName, int makeupPrice, int makeupWeight, int makeupTypeID, int makeupBrandID)
        {
            Makeup makeup = new Makeup()
            {
                MakeupID = makeupID,
                MakeupName = makeupName,
                MakeupPrice = makeupPrice,
                MakeupWeight = makeupWeight,
                MakeupTypeID = makeupTypeID,
                MakeupBrandID = makeupBrandID
            };
            return makeup;
        }
    }
}