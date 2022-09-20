using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IWishListRL
    {
        public bool AddToWishList(int userId, WishListModelCreate wishListModel);
        public bool DeleteWishList(int userId, int wishListId);
    }
}
