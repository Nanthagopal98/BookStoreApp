﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IOrderRL
    {
        public bool PlaceOrder(OrderModel orderModel);
    }
}
