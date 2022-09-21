using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class AddressUpdateModel
    {
        public int AddressId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int AddressType { get; set; } 
    }
}
