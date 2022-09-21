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
    public class FeedBackRL : IFeedBackRL
    {
        public FeedBackRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IConfiguration configuration { get; }

        SqlConnection connection;

        public bool AddFeedBack(FeedBackModel feedBackModel, int userId)
        {
            try
            {
                connection = new SqlConnection(this.configuration.GetConnectionString("DBConnection"));
                connection.Open();
                SqlCommand cmd = new SqlCommand("Add_FeedBack", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Rating", feedBackModel.Rating);
                cmd.Parameters.AddWithValue("@Comment", feedBackModel.Comment);
                cmd.Parameters.AddWithValue("@BookId", feedBackModel.BookId);
                cmd.Parameters.AddWithValue("@UserId", userId);
                var result = cmd.ExecuteNonQuery();
                if (result > 0)
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
