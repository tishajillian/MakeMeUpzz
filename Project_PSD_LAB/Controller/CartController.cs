using Project_PSD_LAB.Handler;
using Project_PSD_LAB.Model;
using Project_PSD_LAB.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_LAB.Controller
{
    public class CartController
    {
        public static User checkCartOwner()
        {
            if (HttpContext.Current.Session != null && HttpContext.Current.Session["user"] != null)
            {
                User cartOwner = (User) HttpContext.Current.Session["user"];
                return cartOwner;
            }
            return null;
        }
        public static Response<Cart> addToCart(int userId, int makeupId, int quantity)
        {
            Response<Cart> response;
            Cart checkCart = CartHandler.getMakeupInCart(userId, makeupId);
            if(checkCart == null)
            {
                response = CartHandler.addCart(CartHandler.generateId(), userId, makeupId, quantity);
                return response;
            }
            response = CartHandler.updateCart(checkCart, quantity);
            return response;
        }
        public static List<object> showCart(int userID)
        {
            return CartHandler.showCart(userID);
        }
        public static void clearCart(int userId)
        {
            CartHandler.clearCart(userId);
        }
        public static List<Cart> getAllCartOfAnUser(int userId)
        {
            return CartHandler.getAllCartOfAnUser(userId);
        }
    }
}