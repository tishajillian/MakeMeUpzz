using Project_PSD_LAB.Handler;
using Project_PSD_LAB.Model;
using Project_PSD_LAB.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Project_PSD_LAB.Controller
{
    public class MakeupController
    {
        public static List<Makeup> getAllMakeup()
        {
            return MakeupHandler.getAllMakeup();
        }
        public static Makeup getMakeupById(int id)
        {
            return MakeupHandler.getMakeupById(id);
        }
        public static Response<Makeup> validateOrder(int quantity)
        {
            if(quantity <= 0)
            {
                return new Response<Makeup>
                {
                    Message = "Quantity must be bigger than 0!",
                    IsSuccess = false,
                    payload = null
                };
            }
            return new Response<Makeup>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static Response<Makeup> checkMakeupName(String name)
        {
            if (name.Length < 1 || name.Length > 99)
            {
                return new Response<Makeup>
                {
                    Message = "Makeup Name length must be between 1 and 99!",
                    IsSuccess = false,
                    payload = null
                };
            }
            return new Response<Makeup>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static Response<Makeup> checkMakeupPrice(int price)
        {
            if(price < 1)
            {
                return new Response<Makeup>
                {
                    Message = "Makeup Price must be greater than or equal to 1!",
                    IsSuccess = false,
                    payload = null
                };
            }
            return new Response<Makeup>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static Response<Makeup> checkMakeupWeight(int weight)
        {
            if (weight > 1500)
            {
                return new Response<Makeup>
                {
                    Message = "Makeup Weight must not be greater than 1500!",
                    IsSuccess = false,
                    payload = null
                };
            }
            return new Response<Makeup>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static Response<Makeup> checkMakeup(String name, String price,
            String weight, String typeId, String brandId)
        {
            if (name.Length == 0)
            {
                return new Response<Makeup>
                {
                    Message = "Makeup Name must not be empty!",
                    IsSuccess = false,
                    payload = null
                };
            }

            Response<Makeup> responseName = MakeupController.checkMakeupName(name);
            if (!responseName.IsSuccess)
            {
                return responseName;
            }

            if (price.Length == 0)
            {
                return new Response<Makeup>
                {
                    Message = "Makeup Price must not be empty!",
                    IsSuccess = false,
                    payload = null
                };
            }

            Response<Makeup> responsePrice = MakeupController.checkMakeupPrice(int.Parse(price));
            if (!responsePrice.IsSuccess)
            {
                return responsePrice;
            }

            if (weight.Length == 0)
            {
                return new Response<Makeup>
                {
                    Message = "Makeup Weight must not be empty!",
                    IsSuccess = false,
                    payload = null
                };
            }

            Response<Makeup> responseWeight = MakeupController.checkMakeupWeight(int.Parse(weight));
            if (!responseWeight.IsSuccess)
            {
                return responseWeight;
            }

            if (typeId.Length == 0)
            {
                return new Response<Makeup>
                {
                    Message = "Makeup Type ID must not be empty!",
                    IsSuccess = false,
                    payload = null
                };
            }

            if (brandId.Length == 0)
            {
                return new Response<Makeup>
                {
                    Message = "Makeup Brand ID must not be empty!",
                    IsSuccess = false,
                    payload = null
                };
            }

            return new Response<Makeup>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static Response<Makeup> checkMakeupTypeBrand(int typeId, int brandId)
        {
            if (MakeupTypeController.isThisMakeupTypeExists(typeId) == null)
            {
                return new Response<Makeup>
                {
                    Message = "Makeup Type ID does not exists!",
                    IsSuccess = false,
                    payload = null
                };
            }

            if (MakeupBrandController.isThisMakeupBrandExists(brandId) == null)
            {
                return new Response<Makeup>
                {
                    Message = "Makeup Brand ID does not exists!",
                    IsSuccess = false,
                    payload = null
                };
            }

            return new Response<Makeup>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static Response<Makeup> addMakeup(String name, int price,
            int weight, int typeId, int brandId)
        {
            Response<Makeup> response = MakeupHandler.addMakeup(MakeupHandler.generateId(), name, price, weight, typeId, brandId);
            return response;
        }
        public static Response<Makeup> updateMakeup(Makeup makeup, String newName, int newPrice,
            int newWeight, int typeId, int brandId)
        {
            Response<Makeup> response = MakeupHandler.updateMakeup(makeup, newName, newPrice, newWeight, typeId, brandId);
            return response;
        }
        public static Response<Makeup> removeMakeup(Makeup makeup)
        {
            Response<Makeup> response = MakeupHandler.removeMakeup(makeup);
            return response;
        }
    }
}