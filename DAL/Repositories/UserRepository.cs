using DAL.DTO;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Tools;
using DAL.ViewModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _connection;

        public UserRepository(IDbConnection connection)
        {
            this._connection = connection;
        }

        public User LoginUser(User user)
        {
            try
            {
                var procedure = "LoginUser";
                var values = new { Email = user.Email, Passwd = user.Passwd};
                return _connection.QueryFirst<User>(procedure, values, commandType : CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User? RegisterUser(User user)
        {
            try
            {
                var procedure = "RegisterUser";
                var values = new {user.Alias, user.Email, user.Passwd};
                return _connection.ExecuteScalar<User?>(procedure, values, commandType :CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        //public User? UpdateUser(int id, UserUpdateDTO user)
        public User? UpdateUser(User user)
        {
            try
            {
                var procedure = "UpdateUser";
                var param = new {user.Id, user.Alias, user.Email,user.Passwd, user.AvatarUrl, user.Country, user.Score, user.Credits};
                return _connection.ExecuteScalar<User>(procedure, param, commandType: CommandType.StoredProcedure);

            }catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public int DeleteUser(int id)
        {
            try
            {
                var procedure = "DeleteUser";
                var param = new { Id = id };
                int result = _connection.Execute(procedure, param, commandType: CommandType.StoredProcedure);

                return result != 0 ? result : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
      
        public IEnumerable<UserViewModel>? GetAll()
        {
            try
            {
                string sql = "SELECT * FROM [dbo].[User] ORDER BY [Score] DESC";
                return _connection.Query<UserViewModel>(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public UserViewModel GetById(int id)
        {
            try
            {
                string sql = "SELECT * FROM [dbo].[User] WHERE Id = @Id";
                var param = new {Id = id};
                return _connection.QueryFirst<UserViewModel>(sql, param);
            }
            catch(Exception ex) 
            { 
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        public UserViewModel GetByAlias(string alias)
        {
            string sql = "SELECT * FROM [dbo].[User] WHERE Alias = @Alias";
            var param = new { Alias = alias };
            return _connection.QueryFirst<UserViewModel>(sql, param);
        }

        public bool EmailAlreadyUsed(string email)
        {
            try
            {
                var procedure = "CheckEmail";
                var param = new { Email = email };
                int result = _connection.Execute(procedure, param, commandType: CommandType.StoredProcedure);
                return result != 0 ? true : false;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
    }
}
