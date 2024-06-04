using Project_PSD_LAB.Handler;
using Project_PSD_LAB.Model;
using Project_PSD_LAB.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_LAB.Controller
{
    public class MakeupTypeController
    {
        public static List<MakeupType> getAllMakeupType()
        {
            return MakeupTypeHandler.getAllMakeupType();
        }
        public static MakeupType getMakeupTypeById(int id)
        {
            return MakeupTypeHandler.getMakeupTypeById(id);
        }
        public static Response<MakeupType> checkTypeName(String name)
        {
            if (name.Length < 1 || name.Length > 99)
            {
                return new Response<MakeupType>
                {
                    Message = "Type Name length must be between 1 and 99!",
                    IsSuccess = false,
                    payload = null
                };
            }
            return new Response<MakeupType>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static Response<MakeupType> checkMakeupType(String name)
        {
            if (name.Length == 0)
            {
                return new Response<MakeupType>
                {
                    Message = "Type Name must not be empty!",
                    IsSuccess = false,
                    payload = null
                };
            }

            Response<MakeupType> responseName = MakeupTypeController.checkTypeName(name);
            if (!responseName.IsSuccess)
            {
                return responseName;
            }

            return new Response<MakeupType>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static Response<MakeupType> addMakeupType(String name)
        {
            Response<MakeupType> response = MakeupTypeHandler.addMakeupType(MakeupTypeHandler.generateId(), name);
            return response;
        }
        public static Response<MakeupType> updateMakeupType(MakeupType makeupType, String newName)
        {
            Response<MakeupType> response = MakeupTypeHandler.updateMakeupType(makeupType, newName);
            return response;
        }
        public static Response<MakeupType> removeMakeupType(MakeupType makeupType)
        {
            Response<MakeupType> response = MakeupTypeHandler.removeMakeupType(makeupType);
            return response;
        }
        public static MakeupType isThisMakeupTypeExists(int id)
        {
            return MakeupTypeHandler.isThisMakeupTypeExists(id);
        }
    }
}