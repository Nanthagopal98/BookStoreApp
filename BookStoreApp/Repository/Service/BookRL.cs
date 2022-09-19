using Microsoft.Extensions.Configuration;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        public bool GetAllBook(int bookId)
        {
            try
            {

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
