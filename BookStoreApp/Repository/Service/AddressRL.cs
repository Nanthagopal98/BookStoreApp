using Microsoft.Extensions.Configuration;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Text;

namespace Repository.Service
{
    public class AddressRL : IAddressRL
    {
        public IConfiguration configuration {get;}

        public AddressRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        SqlConnection connection;

        public bool AddAddress(AddressModel addressModel, int userId)
        {
            try
            {
                connection = new SqlConnection(this.configuration.GetConnectionString("DBConnection"));
                connection.Open();
                SqlCommand command = new SqlCommand("Add_Address", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Address", addressModel.Address);
                command.Parameters.AddWithValue("@City", addressModel.City);
                command.Parameters.AddWithValue("@State", addressModel.State);
                command.Parameters.AddWithValue("@TypeId", addressModel.AddressType);
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
            finally
            {
                connection.Close();
            }
        }
    }
}
