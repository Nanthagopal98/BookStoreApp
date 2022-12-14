using Manager.Interface;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Service
{
    public class WishListBL : IWishListBL
    {

        private readonly IWishListRL wishListRL;

        public WishListBL(IWishListRL wishListRL)
        {
            this.wishListRL = wishListRL;
        }

        public bool AddToWishList(int userId, WishListModelCreate wishListModel)
        {
            try
            {
                return wishListRL.AddToWishList(userId, wishListModel);
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteWishList(int userId, int bookId)
        {
            try
            {
                return wishListRL.DeleteWishList(userId, bookId);
            }
            catch
            {
                throw;
            }
        }

        public List<WishListGetModel> GetWishList(int UserId)
        {
            try
            {
                return wishListRL.GetWishList(UserId);
            }
            catch
            {
                throw;
            }
        }


    }
}
