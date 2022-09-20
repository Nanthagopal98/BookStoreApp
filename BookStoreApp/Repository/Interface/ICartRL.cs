using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface ICartRL
    {
        public bool AddToCart(int UserId, CartModel cartModel);
    }
}
