using Manager.Interface;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Service
{
    public class AddressBL : IAddressBL
    {
        private readonly IAddressRL addressRL;
        public AddressBL(IAddressRL addressRL)
        {
            this.addressRL = addressRL;
        }

        public bool AddAddress(AddressModel addressModel, int userId)
        {
            try
            {
                return addressRL.AddAddress(addressModel, userId);
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateAddress(AddressUpdateModel addressModel, int userId)
        {
            try
            {
                return addressRL.UpdateAddress(addressModel, userId);
            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<AddressUpdateModel> GetAllAddress(int userId)
        {
            try
            {
                return addressRL.GetAllAddress(userId);
            }
            catch
            {
                throw;
            }
        }
    }
}
