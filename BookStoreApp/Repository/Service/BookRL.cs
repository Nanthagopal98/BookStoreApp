using Microsoft.Extensions.Configuration;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace Repository.Service
{
    public class BookRL : IBookRL
    {
        public IConfiguration Configuration { get; }
        public BookRL(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        SqlConnection connection;

        public bool AddBook(BookModel model)
        {
            connection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
            try
            {
                SqlCommand command = new SqlCommand("Add_Book", connection);
                command.CommandType = CommandType.StoredProcedure;
                this.connection.Open();
                command.Parameters.AddWithValue("@BookName", model.BookName);
                command.Parameters.AddWithValue("@AuthorName", model.AuthorName);
                command.Parameters.AddWithValue("@Rating", model.Rating);
                command.Parameters.AddWithValue("@TotalRating", model.TotalRating);
                command.Parameters.AddWithValue("@DiscountPrice", model.DiscountPrice);
                command.Parameters.AddWithValue("@ActualPrice", model.ActualPrice);
                command.Parameters.AddWithValue("@Description", model.Description);
                command.Parameters.AddWithValue("@BookImage", model.BookImage);
                command.Parameters.AddWithValue("@BookQuantity", model.BookQuantity);
                var result = command.ExecuteNonQuery();
                if(result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public List<BookModel> GetAllBook()
        {
            List<BookModel> bookList = new List<BookModel>();
            try
            {
                connection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
                connection.Open();
                SqlCommand command = new SqlCommand("Get_All_Book", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader data = command.ExecuteReader();
                if (data.HasRows) 
                {
                    while (data.Read())
                    {
                        BookModel bookModel = new BookModel();
                        bookModel.BookId = Convert.ToInt32(data["BookId"]);
                        bookModel.BookName = data["BookName"].ToString();
                        bookModel.AuthorName = data["AuthorName"].ToString();
                        bookModel.Rating = data["Rating"].ToString();
                        bookModel.TotalRating = Convert.ToInt32(data["TotalRating"]);
                        bookModel.DiscountPrice = data["DiscountPrice"].ToString();
                        bookModel.ActualPrice = data["ActualPrice"].ToString();
                        bookModel.Description = data["Description"].ToString();
                        bookModel.BookImage = data["BookImage"].ToString();
                        bookModel.BookQuantity = Convert.ToInt32(data["BookQuantity"]);
                        bookList.Add(bookModel);
                    }
                    return bookList;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();   
            }
        }
        public BookModel GetBookById(int bookId)
        {
            try
            {
                connection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
                SqlCommand cmd = new SqlCommand("Get_Book_By_Id", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                cmd.Parameters.AddWithValue("@BookId", bookId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    BookModel bookModel = new BookModel();
                    while (reader.Read())
                    {
                        
                        bookModel.BookId = Convert.ToInt32(reader["BookId"]);
                        bookModel.BookName = reader["BookName"].ToString();
                        bookModel.AuthorName = reader["AuthorName"].ToString();
                        bookModel.Rating = reader["Rating"].ToString();
                        bookModel.TotalRating = Convert.ToInt32(reader["TotalRating"]);
                        bookModel.DiscountPrice = reader["DiscountPrice"].ToString();
                        bookModel.ActualPrice = reader["ActualPrice"].ToString();
                        bookModel.Description = reader["Description"].ToString();
                        bookModel.BookImage = reader["BookImage"].ToString();
                        bookModel.BookQuantity = Convert.ToInt32(reader["BookQuantity"]);
                    }
                    return bookModel;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool UpdateBook(BookModel model)
        {
            try
            {
                connection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
                SqlCommand command = new SqlCommand("Update_Book", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                command.Parameters.AddWithValue("@BookId", model.BookId);
                command.Parameters.AddWithValue("@BookName", model.BookName);
                command.Parameters.AddWithValue("@AuthorName", model.AuthorName);
                command.Parameters.AddWithValue("@Rating", model.Rating);
                command.Parameters.AddWithValue("@TotalRating", model.TotalRating);
                command.Parameters.AddWithValue("@DiscountPrice", model.DiscountPrice);
                command.Parameters.AddWithValue("@ActualPrice", model.ActualPrice);
                command.Parameters.AddWithValue("@Description", model.Description);
                command.Parameters.AddWithValue("@BookImage", model.BookImage);
                command.Parameters.AddWithValue("@BookQuantity", model.BookQuantity);
                var result =  command.ExecuteNonQuery();
                if(result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public bool DeleteBook(int bookId)
        {
            try
            {
                connection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
                this.connection.Open();
                SqlCommand command = new SqlCommand("Delete_Book", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BookId", bookId);
                var result = command.ExecuteNonQuery();
                if(result > 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
