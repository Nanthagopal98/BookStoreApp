using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interface
{
    public interface IAddressBL
    {
        public bool AddAddress(AddressModel addressModel, int userId);
        public bool UpdateAddress(AddressUpdateModel addressModel, int userId);
        public IEnumerable<AddressUpdateModel> GetAllAddress(int userId);
    }
}
