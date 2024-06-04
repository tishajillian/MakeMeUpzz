using Project_PSD_LAB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_LAB.Factory
{
    public class CartFactory
    {
        public static Cart CreateCart(int cartID, int userID, int makeupID, int quantity)
        {
            Cart cart = new Cart()
            {
                CartID = cartID,
                UserID = userID,
                MakeupID = makeupID,
                Quantity = quantity
            };
            return cart;
        }
    }
}