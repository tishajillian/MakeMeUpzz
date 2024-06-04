using Project_PSD_LAB.Handler;
using Project_PSD_LAB.Model;
using Project_PSD_LAB.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Project_PSD_LAB.Controller
{
    public class MakeupBrandController
    {
        public static List<MakeupBrand> getAllMakeupBrand()
        {
            return MakeupBrandHandler.getAllMakeupBrands();
        }
        public static Response<MakeupBrand> checkBrandName(String name)
        {
            if(name.Length < 1 || name.Length > 99)
            {
                return new Response<MakeupBrand>
                {
                    Message = "Brand Name length must be between 1 and 99!",
                    IsSuccess = false,
                    payload = null
                };
            }
            return new Response<MakeupBrand>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };

        }
        public static Response<MakeupBrand> checkBrandRating(int rating)
        {
            if (rating < 0 || rating > 100)
            {
                return new Response<MakeupBrand>
                {
                    Message = "Brand Rating must be between 0 and 100!",
                    IsSuccess = false,
                    payload = null
                };
            }
            return new Response<MakeupBrand>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };

        }
        public static Response<MakeupBrand> checkMakeupBrand(String name, String rating)
        {
            if (name.Length == 0)
            {
                return new Response<MakeupBrand>
                {
                    Message = "Brand Name must not be empty!",
                    IsSuccess = false,
                    payload = null
                };
            }

            Response <MakeupBrand> responseName = MakeupBrandController.checkBrandName(name);
            if(!responseName.IsSuccess)
            {
                return responseName;
            }

            if (rating.Length == 0)
            {
                return new Response<MakeupBrand>
                {
                    Message = "Brand Rating must not be empty!",
                    IsSuccess = false,
                    payload = null
                };
            }

            Response<MakeupBrand> responseRating = MakeupBrandController.checkBrandRating(int.Parse(rating));
            if(!responseRating.IsSuccess)
            {
                return responseRating;
            }

            return new Response<MakeupBrand>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static Response<MakeupBrand> addMakeupBrand(String name, int rating)
        {
            Response<MakeupBrand> response = MakeupBrandHandler.addMakeupBrand(MakeupBrandHandler.generateId(), name, rating);
            return response;
        }
        public static MakeupBrand getMakeupBrandById(int id)
        {
            return MakeupBrandHandler.getMakeupBrandById(id);
        }
        public static Response<MakeupBrand> updateMakeupBrand(MakeupBrand makeupBrand, String newName, int newRating)
        {
            Response<MakeupBrand> response = MakeupBrandHandler.updateMakeupBrand(makeupBrand, newName, newRating);
            return response;
        }
        public static Response<MakeupBrand> removeMakeupBrand(MakeupBrand makeupBrand)
        {
            Response<MakeupBrand> response = MakeupBrandHandler.removeMakeupBrand(makeupBrand);
            return response;
        }
        public static MakeupBrand isThisMakeupBrandExists(int id)
        {
            return MakeupBrandHandler.isThisMakeupBrandExists(id);
        }
    }
}