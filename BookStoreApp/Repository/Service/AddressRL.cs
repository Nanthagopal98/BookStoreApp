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

        public bool UpdateAddress(AddressUpdateModel addressModel, int userId)
        {
            try
            {
                connection = new SqlConnection(this.configuration.GetConnectionString("DBConnection"));
                connection.Open();
                SqlCommand command = new SqlCommand("Update_Address", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@AddressId", addressModel.AddressId);
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
                connection.Close ();
            }
        }

        public IEnumerable<AddressUpdateModel> GetAllAddress(int userId)
        {
            try
            {
                List<AddressUpdateModel> updateModel = new List<AddressUpdateModel> ();
                connection = new SqlConnection(this.configuration.GetConnectionString("DBConnection"));
                connection.Open();
                SqlCommand command = new SqlCommand("Get_Address", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", userId);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AddressUpdateModel model = new AddressUpdateModel();
                        model.AddressId = Convert.ToInt32(reader["AddressId"]);
                        model.Address = reader["Address"].ToString();
                        model.City = reader["City"].ToString ();
                        model.State = reader["State"].ToString () ;
                        model.AddressType = Convert.ToInt32(reader["TypeId"]);

                        updateModel.Add(model);
                        
                    }
                    return updateModel;
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
                connection.Close();
            }
        }
    }
}
