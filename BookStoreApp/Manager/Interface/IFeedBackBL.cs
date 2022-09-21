using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interface
{
    public interface IFeedBackBL
    {
        public bool AddFeedBack(FeedBackModel feedBackModel, int userId);
        public IEnumerable<FeedBackGetModel> GetAllFeedBack(int userId);
    }
}
