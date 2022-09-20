﻿using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interface
{
    public interface IWishListBL
    {
        public bool AddToWishList(int userId, WishListModelCreate wishListModel);
        public bool DeleteWishList(int userId, int wishListId);
        public List<WishListGetModel> GetWishList(int UserId);
    }
}
