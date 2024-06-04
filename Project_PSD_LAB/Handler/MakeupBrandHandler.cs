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
    public class MakeupBrandHandler
    {
        public static List<MakeupBrand> getAllMakeupBrands()
        {
            return MakeupBrandRepository.getAllMakeupBrands();
        }
        public static int generateId()
        {
            MakeupBrand makeupBrand = MakeupBrandRepository.getLastMakeupBrand();
            if (makeupBrand == null)
            {
                return 1;
            }
            int lastId = makeupBrand.MakeupBrandID;
            lastId++;
            return lastId;
        }
        public static Response<MakeupBrand> addMakeupBrand(int makeupBrandId, String name, int rating)
        {
            MakeupBrand makeupBrand = MakeupBrandFactory.CreateMakeupBrand(makeupBrandId, name, rating);
            MakeupBrandRepository.addMakeupBrand(makeupBrand);
            return new Response<MakeupBrand>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static MakeupBrand getMakeupBrandById(int id)
        {
            return MakeupBrandRepository.getMakeupBrandById(id);
        }
        public static Response<MakeupBrand> updateMakeupBrand(MakeupBrand makeupBrand, String newName, int newRating)
        {
            MakeupBrandRepository.updateMakeupBrand(makeupBrand, newName, newRating);
            return new Response<MakeupBrand>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static Response<MakeupBrand> removeMakeupBrand(MakeupBrand makeupBrand)
        {
            MakeupBrandRepository.removeMakeupBrand(makeupBrand);
            return new Response<MakeupBrand>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static MakeupBrand isThisMakeupBrandExists(int id)
        {
            return MakeupBrandRepository.isThisMakeupBrandExists(id);
        }
    }
}