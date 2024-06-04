using Project_PSD_LAB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Project_PSD_LAB.Repository
{
    public class CartRepository
    {
        private static Database1Entities1 db = new Database1Entities1();
        public static List<object> showCart(int userId)
        {
            var cartItems = (from x in db.Carts
                             join Makeup in db.Makeups on x.MakeupID equals Makeup.MakeupID
                             join MakeupBrand in db.MakeupBrands on Makeup.MakeupBrandID equals MakeupBrand.MakeupBrandID
                             join MakeupType in db.MakeupTypes on Makeup.MakeupTypeID equals MakeupType.MakeupTypeID
                             where x.UserID == userId
                             select new
                             {
                                 Name = Makeup.MakeupName,
                                 Price = Makeup.MakeupPrice,
                                 Weight = Makeup.MakeupWeight,
                                 TypeName = MakeupType.MakeupTypeName,
                                 Brand = MakeupBrand.MakeupBrandName,
                                 Quantity = x.Quantity,
                                 Total = x.Quantity * Makeup.MakeupPrice
                             }).ToList<object>();
            return cartItems;           
        }
        public static List<Cart> getAllCartOfAnUser(int userId)
        {
            return (from x in db.Carts
                    where x.UserID == userId
                    select x).ToList();
        }
        public static Cart getMakeupInCart(int userId, int makeupId)
        {
            return (from x in db.Carts where x.UserID == userId
                    && x.MakeupID == makeupId select x).FirstOrDefault();
        }
        public static Cart getLastCart()
        {
            return db.Carts.ToList().LastOrDefault();
        }
        public static void createCart(Cart cart)
        {
            db.Carts.Add(cart);
            db.SaveChanges();
        }
        public static void updateQuantity(Cart cart, int quantity)
        {
            cart.Quantity += quantity;
            db.SaveChanges();
        }
        public static void clearCart(int userId)
        {
            var cart = (from x in db.Carts
                         where x.UserID == userId
                         select x).ToList();
            
            if(cart.Any() )
            {
                db.Carts.RemoveRange(cart);
                db.SaveChanges();
            }          
        }
    }
}