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
    public class MakeupHandler
    {
        public static List<Makeup> getAllMakeup()
        {
            return MakeupRepository.getAllMakeup();
        }
        public static Makeup getMakeupById(int id)
        {
            return MakeupRepository.getMakeupById(id);
        }
        public static int generateId()
        {
            Makeup makeup = MakeupRepository.getLastMakeup();
            if (makeup == null)
            {
                return 1;
            }
            int lastId = makeup.MakeupID;
            lastId++;
            return lastId;
        }
        public static Response<Makeup> addMakeup(int id, String name, int price,
            int weight, int typeId, int brandId)
        {
            Makeup makeup = MakeupFactory.CreateMakeup(id, name, price, weight, typeId, brandId);
            MakeupRepository.addMakeup(makeup);
            return new Response<Makeup>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static Response<Makeup> updateMakeup(Makeup makeup, String newName, int newPrice,
            int newWeight, int typeId, int brandId)
        {
            MakeupRepository.updateMakeup(makeup, newName, newPrice, newWeight, typeId, brandId);
            return new Response<Makeup>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static Response<Makeup> removeMakeup(Makeup makeup)
        {
            MakeupRepository.removeMakeup(makeup);
            return new Response<Makeup>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
    }
}