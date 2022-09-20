using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interface
{
    public interface ICartBL
    {
        public bool AddToCart(int UserId, CartModel cartModel);
        public bool UpdateCart(int userId, CartUpdateModel cartUpdateModel);
        public bool DeleteCart(int cartId, int userId);
    }
}
