using Project_PSD_LAB.Factory;
using Project_PSD_LAB.Model;
using Project_PSD_LAB.Modules;
using Project_PSD_LAB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_LAB.Handler
{
    public class MakeupTypeHandler
    {
        public static List<MakeupType> getAllMakeupType()
        {
            return MakeupTypeRepository.getAllMakeupType();
        }
        public static MakeupType getMakeupTypeById(int id)
        {
            return MakeupTypeRepository.getMakeupTypeById(id);
        }
        public static int generateId()
        {
            MakeupType makeupType = MakeupTypeRepository.getLastMakeupType();
            if (makeupType == null)
            {
                return 1;
            }
            int lastId = makeupType.MakeupTypeID;
            lastId++;
            return lastId;
        }
        public static Response<MakeupType> addMakeupType(int id, String name)
        {
            MakeupType makeupType = MakeupTypeFactory.CreateMakeupType(id, name);
            MakeupTypeRepository.addMakeupType(makeupType);
            return new Response<MakeupType>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static Response<MakeupType> updateMakeupType(MakeupType makeupType, String newName)
        {
            MakeupTypeRepository.updateMakeupType(makeupType, newName);
            return new Response<MakeupType>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static Response<MakeupType> removeMakeupType(MakeupType makeupType)
        {
            MakeupTypeRepository.removeMakeupType(makeupType);
            return new Response<MakeupType>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static MakeupType isThisMakeupTypeExists(int id)
        {
            return MakeupTypeRepository.isThisMakeupTypeExists(id);
        }
    }
}