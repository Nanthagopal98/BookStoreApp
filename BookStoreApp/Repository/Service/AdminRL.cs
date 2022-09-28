using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Repository.Service
{
    public class AdminRL : IAdminRL
    {
        public AdminRL(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        SqlConnection sqlConnection;
        public string AdminLogin(LoginModel loginModel)
        {
            
        sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
            using (sqlConnection)
            {
                try
                {
                    SqlCommand command = new SqlCommand("Admin_Login", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;

                    sqlConnection.Open();

                    command.Parameters.AddWithValue("@Email", loginModel.Email);
                    command.Parameters.AddWithValue("@Password", loginModel.Password);

                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        string query = "SELECT AdminId FROM Admin WHERE AdminEmailID = '" + result + "'";
                        SqlCommand cmd = new SqlCommand(query, sqlConnection);
                        string getId = cmd.ExecuteScalar().ToString();
                        int Id = Int32.Parse(getId);
                        string token = GenerateSecurityToken(result.ToString(), Id);
                        return token;
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
                    sqlConnection.Close();
                }
            }
        }
        public GetAdminModel GetAdmin()
        {

            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
            using (sqlConnection)
            {
                try
                {
                    GetAdminModel getAdminModel = new GetAdminModel();
                    SqlCommand command = new SqlCommand("Get_Admin", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            
                            getAdminModel.AdminEmailID = reader["AdminEmailID"].ToString();
                            getAdminModel.AdminPhone = reader["AdminPhone"].ToString();
                            getAdminModel.Address = reader["Address"].ToString();
                        }
                        return getAdminModel;
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
                    sqlConnection.Close();
                }
            }
        }
        public string GenerateSecurityToken(string email, int Id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration[("JWT:Key")]));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Email, email),
                    new Claim("Id", Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
