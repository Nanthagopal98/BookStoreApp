using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class CartGet
    {
        public int CartId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string Rating { get; set; }
        public int TotalRating { get; set; }
        public string DiscountPrice { get; set; }
        public string ActualPrice { get; set; }
        public string Description { get; set; }
        public string BookImage { get; set; }
        public int BookQuantity { get; set; }
    }
}
