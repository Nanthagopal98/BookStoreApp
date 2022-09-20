using Microsoft.Extensions.Configuration;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Repository.Service
{
    public class CartRL : ICartRL
    {
        public IConfiguration configuration;
        public CartRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        SqlConnection connection;

        public bool AddToCart(int UserId, CartModel cartModel)
        {
            try
            {
                connection = new SqlConnection(this.configuration.GetConnectionString("DBConnection"));
                connection.Open();
                string query = "SELECT BookId FROM Cart";
                SqlCommand  cmd = new SqlCommand(query, connection);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                bool result = false;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = Convert.ToInt32(reader["BookId"]);
                        result = (id == cartModel.BookId);
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
                if(result == false)
                {
                    reader.Close();
                    SqlCommand command = new SqlCommand("Add_To_Cart", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Quantity", cartModel.Quantity);
                    command.Parameters.AddWithValue("@UserId", UserId);
                    command.Parameters.AddWithValue("@BookId", cartModel.BookId);
                    var output = command.ExecuteNonQuery();
                    if(output > 0)
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
