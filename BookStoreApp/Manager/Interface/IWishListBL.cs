using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interface
{
    public interface IWishListBL
    {
        public bool AddToWishList(int userId, WishListModelCreate wishListModel);
    }
}
