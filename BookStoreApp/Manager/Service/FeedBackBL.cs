using Manager.Interface;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Service
{
    public class FeedBackBL : IFeedBackBL
    {
        private readonly IFeedBackRL feedBackRL;
        public FeedBackBL(IFeedBackRL feedBackRL)
        {
            this.feedBackRL = feedBackRL;
        }

        public bool AddFeedBack(FeedBackModel feedBackModel, int userId)
        {
            try
            {
                return feedBackRL.AddFeedBack(feedBackModel, userId);
            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<FeedBackGetModel> GetAllFeedBack(int userId)
        {
            try
            {
                return feedBackRL.GetAllFeedBack(userId);
            }
            catch
            {
                throw;
            }
        }
    }
}
