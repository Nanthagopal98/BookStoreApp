using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Interface
{
    public interface IBookBL
    {
        public bool AddBook(BookModel model);
        public List<BookModel> GetAllBook();
        public BookModel GetBookById(int bookId);
        public bool UpdateBook(BookModel model);
        public bool DeleteBook(int bookId);
    }
}
