using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IBookRL
    {
        public bool AddBook(BookModel model);
        public List<BookModel> GetAllBook();
    }
}
