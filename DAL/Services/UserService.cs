using DAL.DTO;
using DAL.Entities;
using DAL.Repositories;
using DAL.Tools;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class UserService : IUserRepository
    {
        private readonly IDbConnection _connection;

        public UserService(IDbConnection connection)
        {
            this._connection = connection;
        }
        public void LoginUser(UserLoginDTO user)
        {
            var procedure = "LoginUser";
            var values = new { user.Email, user.Passwd};
            _connection.Query(procedure, values, commandType : CommandType.StoredProcedure);
        }

        public void RegisterUser(UserRegisterDTO user)
        {
            var procedure = "RegisterUser";
            var values = new {user.Alias, user.Email, user.Passwd};
            _connection.Query(procedure, values, commandType :CommandType.StoredProcedure);
        }

        public void UpdateUser(int id, UserUpdateDTO user)
        {
            var procedure = "UpdateUser";
            var param = new {Id = id, user.Alias, user.Email,user.Passwd, user.AvatarUrl, user.Country};
            _connection.Query(procedure, param, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteUser(int id)
        {
            string sql = "DELETE FROM [dbo].[User] WHERE @ID = Id" +
                "DELETE FROM [dbo].[User_Stats] WHERE @UserID = Id";
            var param = new { ID = id };
            await _connection.QueryAsync(sql, param);
        }
      
        public async Task<IEnumerable<User>> GetAll()
        {
            string sql = "SELECT * FROM [dbo].[User]";
            return await _connection.QueryAsync<User>(sql);
        }

        public async Task<User> GetById(int id)
        {
            string sql = "SELECT * FROM [dbo].[User] WHERE Id = @Id";
            var param = new {Id = id};
            return await _connection.QueryFirstAsync<User>(sql, param);
        }


        public async Task<User> GetByAlias(string alias)
        {
            string sql = "SELECT * FROM [dbo].[User] WHERE Alias = @Alias";
            var param = new { Alias = alias };
            return await _connection.QueryFirstAsync<User>(sql, param);
        }
    }
}
