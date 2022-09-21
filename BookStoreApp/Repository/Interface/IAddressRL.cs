using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IAddressRL
    {
        public bool AddAddress(AddressModel addressModel, int userId);
        public bool UpdateAddress(AddressUpdateModel addressModel, int userId);
        public IEnumerable<AddressUpdateModel> GetAllAddress(int userId);
    }
}
