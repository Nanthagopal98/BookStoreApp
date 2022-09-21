using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interface
{
    public interface IOrderBL
    {
        public bool PlaceOrder(OrderModel orderModel);
    }
}
