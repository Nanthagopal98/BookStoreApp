using Manager.Interface;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Service
{
    public class BookBL :IBookBL
    {
        public IBookRL bookRL;

        public BookBL(IBookRL bookRL)
        {
            this.bookRL = bookRL;
        }
        public bool AddBook(BookModel model)
        {
            try
            {
                return bookRL.AddBook(model);
            }
            catch
            {
                throw;
            }
        }
        public List<BookModel> GetAllBook()
        {
            try
            {
                return bookRL.GetAllBook();
            }
            catch
            {
                throw;
            }
        }
        public BookModel GetBookById(int bookId)
        {
            try
            {
                return bookRL.GetBookById(bookId);
            }
            catch
            {
                throw;
            }
        }
        public bool UpdateBook(BookModel model)
        {
            try
            {
                return bookRL.UpdateBook(model);
            }
            catch
            {
                throw;
            }
        }
        public bool DeleteBook(int bookId)
        {
            try
            {
                return bookRL.DeleteBook(bookId);
            }
            catch
            {
                throw;
            }
        }
    }
}
