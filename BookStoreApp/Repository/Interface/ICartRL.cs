using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface ICartRL
    {
        public bool AddToCart(int UserId, CartModel cartModel);
        public bool UpdateCart(int userId, CartUpdateModel cartUpdateModel);
        public bool DeleteCart(int bookId, int userId);
        public List<CartGet> GetCart(int userId);
    }
}
