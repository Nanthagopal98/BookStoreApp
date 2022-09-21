using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interface
{
    public interface IAddressBL
    {
        public bool AddAddress(AddressModel addressModel, int userId);
    }
}
