using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IOrderRL
    {
        public bool PlaceOrder(OrderModel orderModel);
        public bool CancelOrder(int orderId, int UserId);
        public IEnumerable<GetOrderModel> GetOrder(int UserId);
    }
}
