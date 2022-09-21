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
    public class OrderRL : IOrderRL
    {
        public IConfiguration configuration { get; }

        public OrderRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        SqlConnection connection;

        public bool PlaceOrder(OrderModel orderModel)
        {
            try
            {
                connection = new SqlConnection(this.configuration.GetConnectionString("DBConnection"));
                connection.Open();
                SqlCommand command = new SqlCommand("Place_Order", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CartId", orderModel.CartId);
                command.Parameters.AddWithValue("@AddressId", orderModel.AddressId);
                command.Parameters.AddWithValue("@DateTime", orderModel.DateTime);
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
            finally
            {
                connection.Close();
            }
        }

        public bool CancelOrder(int orderId, int UserId)
        {
            try
            {
                connection = new SqlConnection(this.configuration.GetConnectionString("DBConnection"));
                connection.Open();
                SqlCommand command = new SqlCommand("Cancel_Order", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@orderId", orderId);
                command.Parameters.AddWithValue("@UserId", UserId);
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
                connection.Close();
            }
        }
    }
}
