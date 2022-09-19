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
    }
}
