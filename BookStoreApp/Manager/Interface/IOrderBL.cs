using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interface
{
    public interface IOrderBL
    {
        public bool PlaceOrder(OrderModel orderModel);
        public bool CancelOrder(int orderId, int UserId);
        public IEnumerable<GetOrderModel> GetOrder(int UserId);
    }
}
