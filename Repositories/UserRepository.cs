﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using LoginForm.Models;

namespace LoginForm.Repositories
{
    public class UserRepository: RepositoryBase, IUserRepository
    {
        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = getConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [User] WHERE username=@username AND [password]=@password";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }

            return validUser;
        }

        public void Add(UserModel userModel)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(UserModel userModel)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public UserModel GetByUsername(string username)
        {
            UserModel user=null;
            using (var connection = getConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [User] WHERE username=@username";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                using (var reader =command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = reader[0].ToString(),
                            Username = reader[1].ToString(),
                            Password = string.Empty,
                            Name = reader[3].ToString(),
                            LastName = reader[4].ToString(),
                            Email = reader[5].ToString(),
                        };
                    }
                }

            }

            return user;
        }

        public IEnumerable<UserModel> GetByAll()
        {
            throw new System.NotImplementedException();
        }
    }
}