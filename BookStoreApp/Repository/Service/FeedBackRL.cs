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
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public IEnumerable<FeedBackGetModel> GetAllFeedBack(int userId)
        {
            List<FeedBackGetModel> getFeedback = new List<FeedBackGetModel>();
            try
            {
                connection = new SqlConnection(this.configuration.GetConnectionString("DBConnection"));
                connection.Open();
                SqlCommand command = new SqlCommand("Get_Feedback", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", userId);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        FeedBackGetModel model = new FeedBackGetModel();
                        model.FeedBackId = Convert.ToInt32(reader["FeedBackId"]);
                        model.Rating = Convert.ToInt32(reader["Rating"]);
                        model.Comment = reader["Comment"].ToString();
                        model.BookId = Convert.ToInt32(reader["BookId"]);

                        getFeedback.Add(model);
                    }
                    return getFeedback;
                }
                else
                {
                    return null;
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
    }
}
