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

        public bool DeleteCart(int bookId, int userId)
        {
            try
            {
                return cartRL.DeleteCart(bookId, userId);
            }
            catch
            {
                throw;
            }
        }
        public List<CartGet> GetCart(int userId)
        {
            try
            {
                return cartRL.GetCart(userId);
            }
            catch
            {
                throw;
            }
        }
    }
}
