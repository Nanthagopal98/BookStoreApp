using Manager.Interface;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Service
{
    public class CartBL : ICartBL
    {
        public ICartRL cartRL;
        public CartBL(ICartRL cartRL)
        {
            this.cartRL = cartRL;
        }

        public bool AddToCart(int UserId, CartModel cartModel)
        {
            try
            {
                return cartRL.AddToCart(UserId, cartModel);
            }
            catch
            {
                throw;
            }
        }

        public bool UpdateCart(int userId, CartUpdateModel cartUpdateModel)
        {
            try
            {
                return cartRL.UpdateCart(userId, cartUpdateModel);
            }
            catch
            {
                throw;
            }
        }
    }
}
