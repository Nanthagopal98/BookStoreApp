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
        public BookModel GetBookById(int bookId);
        public bool UpdateBook(BookModel model);
        public bool DeleteBook(int bookId);
    }
}
