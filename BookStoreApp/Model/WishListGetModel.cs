using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class WishListGetModel
    {
        public int WishListId { get; set; } 
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}
