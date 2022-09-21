using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class FeedBackGetModel
    {
        public int FeedBackId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int BookId { get; set; }
    }
}
