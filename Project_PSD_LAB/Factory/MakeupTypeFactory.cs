using Project_PSD_LAB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_LAB.Factory
{
    public class MakeupTypeFactory
    {
        public static MakeupType CreateMakeupType (int makeupTypeID, String makeupTypeName)
        {
            MakeupType makeupType = new MakeupType()
            {
                MakeupTypeID = makeupTypeID,
                MakeupTypeName = makeupTypeName
            };
            return makeupType;        
        }
    }
}