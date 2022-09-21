using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IFeedBackRL
    {
        public bool AddFeedBack(FeedBackModel feedBackModel, int userId);
        public IEnumerable<FeedBackGetModel> GetAllFeedBack(int userId);
    }
}
