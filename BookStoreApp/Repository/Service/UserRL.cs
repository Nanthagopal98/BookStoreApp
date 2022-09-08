using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using Repository.Interface;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Repository.Service
{
    public class UserRL : IUserRL
    {
        public UserRL(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        SqlConnection sqlConnection;

        public bool Registration(RegisterModel model)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
            using (sqlConnection)
            {
                try
                {
                    SqlCommand command = new SqlCommand("dbo.Add_User", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;

                    sqlConnection.Open();

                    command.Parameters.AddWithValue("@UserName", model.FullName);
                    command.Parameters.AddWithValue("@Email", model.Email);
                    command.Parameters.AddWithValue("@Phone", model.Phone);
                    command.Parameters.AddWithValue("@Password", model.Password);


                    var result = command.ExecuteNonQuery();
                    if (result > 0)
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
                    sqlConnection.Close();
                }
            }
        }
        public string UserLogin(LoginModel loginModel)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
            using (sqlConnection)
            {
                try
                {
                    SqlCommand command = new SqlCommand("User_Login", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;

                    sqlConnection.Open();
                    
                    command.Parameters.AddWithValue("@Email", loginModel.Email);
                    command.Parameters.AddWithValue("@Password", loginModel.Password);

                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        string query = "SELECT UserId FROM Users WHERE EmaiL = '" + result+"'";
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
                catch(Exception e)
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
                    new Claim(ClaimTypes.Email, email),
                    new Claim("Id", Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public string ForgetPassword(string email)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    string query = "SELECT EmaiL FROM Users WHERE Email = '" + email + "'";
                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        string idQuery = "SELECT UserId FROM Users WHERE EmaiL = '" + result + "'";
                        SqlCommand cmd = new SqlCommand(idQuery, sqlConnection);
                        int id = Int32.Parse(cmd.ExecuteScalar().ToString());
                        var token = GenerateSecurityToken(result.ToString(), id);
                        MSMQModel msmqModel = new MSMQModel();
                        msmqModel.sendDatatoQueue(token);
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

        public bool ResetPassword(string email, string password, string confirmPassword)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("DBConnection"));
            using (sqlConnection)
            {
                try
                {
                    if(password == confirmPassword)
                    {
                        sqlConnection.Open();
                        SqlCommand command = new SqlCommand("Reset_Password", sqlConnection);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", password);  
                        command.CommandType = CommandType.StoredProcedure;
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
                    else
                    {
                        return false;
                    }
                }
                catch(Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
    }
}
