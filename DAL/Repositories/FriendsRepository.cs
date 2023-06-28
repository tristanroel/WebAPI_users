using DAL.DTO;
using DAL.Entities;
using DAL.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class FriendsRepository : IFriendRepository
    {
        private readonly IDbConnection _connection;

        public FriendsRepository(IDbConnection connection)
        {
            this._connection = connection;
        }

        public void AddNewFriend(int User_Id, int Friend_Id)
        {
            try
            {
                string sql = "INSERT INTO [dbo].[Friend](User_Id,Friend_Id) VALUES (@User_Id,@Friend_Id)";
                var param = new { User_Id = User_Id, Friend_Id = Friend_Id };
                _connection.QueryFirstAsync(sql, param);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteFriend(int Id)
        {
            try
            {
                string sql = "DELETE FROM [dbo].[Friend] WHERE [Id] = @Id";
                var param = new { Id = Id };
                _connection.QueryFirst(sql, param);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<IEnumerable<Friend>> GetAllFriends()
        {
            try
            {
                string sql = "SELECT * FROM [dbo].[Friend]";
                return await _connection.QueryAsync<Friend>(sql);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return new List<Friend>();
            }
        }

        public async Task<IEnumerable<Friend>> GetAllFriendsOfUser(int id)
        {
            try
            {
                string sql = "SELECT * FROM [dbo].[Friend] WHERE [User_Id] = @User_Id";
                var param = new { User_Id = id };
                return await _connection.QueryAsync<Friend>(sql, param);

            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return Enumerable.Empty<Friend>();
            }
        }

    }
}
