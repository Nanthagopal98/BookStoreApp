using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interface
{
    public interface IBookBL
    {
        public bool AddBook(BookModel model);
    }
}
