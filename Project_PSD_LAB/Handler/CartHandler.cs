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
    public class CartHandler
    {
        public static List<object> showCart(int userID)
        {
            return CartRepository.showCart(userID);
        }
        public static int generateId()
        {
            Cart cart = CartRepository.getLastCart();
            if (cart == null)
            {
                return 1;
            }
            int lastId = cart.CartID;
            lastId++;
            return lastId;
        }
        public static Cart getMakeupInCart(int userId, int makeupId)
        {
            return CartRepository.getMakeupInCart(userId, makeupId);
        }
        public static Response<Cart> addCart(int cartId, int userId, int makeupId, int quantity)
        {
           Cart cart = CartFactory.CreateCart(cartId, userId, makeupId, quantity);
           CartRepository.createCart(cart);
           return new Response<Cart>
           {
                    Message = "Success",
                    IsSuccess = true,
                    payload = null
           };
        }  
        public static Response<Cart> updateCart(Cart cart, int quantity)
        {
            CartRepository.updateQuantity(cart, quantity);
            return new Response<Cart>
            {
                Message = "Success",
                IsSuccess = true,
                payload = null
            };
        }
        public static void clearCart(int userId)
        {
            CartRepository.clearCart(userId);
        }
        public static List<Cart> getAllCartOfAnUser(int userId)
        {
            return CartRepository.getAllCartOfAnUser(userId);
        }
    }
}