using Project_PSD_LAB.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project_PSD_LAB.Factory
{
    public class MakeupBrandFactory
    {
        public static MakeupBrand CreateMakeupBrand (int makeupBrandID, String makeupBrandName, int makeupBrandRating)
        {
            MakeupBrand makeupBrand = new MakeupBrand()
            {
                MakeupBrandID = makeupBrandID,
                MakeupBrandName = makeupBrandName,
                MakeupBrandRating = makeupBrandRating
            };
            return makeupBrand;
        }
    }
}