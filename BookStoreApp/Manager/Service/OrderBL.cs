using Manager.Interface;
using Model;
using Repository.Interface;
using Repository.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Service
{
    public class OrderBL : IOrderBL
    {
        public readonly IOrderRL orderRL;

        public OrderBL(IOrderRL orderRL)
        {
            this.orderRL = orderRL;
        }

        public bool PlaceOrder(OrderModel orderModel)
        {
            try
            {
                return orderRL.PlaceOrder(orderModel);
            }
            catch
            {
                throw;
            }
        }
    }
}
