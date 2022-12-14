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
    public class WishListRL : IWishListRL
    {
        public IConfiguration Configuration { get; }

        public WishListRL(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        SqlConnection connection;

        public bool AddToWishList(int userId, WishListModelCreate wishListModel)
        {
            try
            {
                connection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
                connection.Open();
                string query = "SELECT BookId FROM WishList WHERE UserId =" + userId;
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                bool result = false;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = Convert.ToInt32(reader["BookId"]);
                        result = (id == wishListModel.BookId);
                        if (result == true)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    result = false;
                }
                if (result == false)
                {
                    reader.Close();
                    SqlCommand command = new SqlCommand("Add_To_WishList", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@BookId", wishListModel.BookId);
                    var output = command.ExecuteNonQuery();
                    if (output > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public bool DeleteWishList(int userId, int bookId)
        {
            try
            {
                connection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
                connection.Open();
                SqlCommand command = new SqlCommand("Delete_Book_WishList", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@bookId", bookId);
                command.Parameters.AddWithValue("@UserId", userId);
                var result = command.ExecuteNonQuery();
                if(result > 0)
                {
                    return true;
                }
                return false;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<WishListGetModel> GetWishList(int UserId)
        {
            try
            {
                List<WishListGetModel> getList = new List<WishListGetModel>();
                connection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
                connection.Open();
                SqlCommand command = new SqlCommand("Get_Procedure_WishList", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", UserId);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        WishListGetModel model = new WishListGetModel();
                        model.WishListId = Convert.ToInt32(reader["WishListId"]);
                        model.UserId = Convert.ToInt32(reader["UserId"]);
                        model.BookId = Convert.ToInt32(reader["BookId"]);
                        getList.Add(model);
                    }
                    return getList;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
