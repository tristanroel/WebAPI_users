using DAL.Entities;
using DAL.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class User_StatsService : IUser_StatsRepository
    {
        private readonly IDbConnection _connection;

        public User_StatsService(IDbConnection connection)
        {
            this._connection = connection;
        }

        public async Task<User_Stats> SetStatistic(int id, User_Stats stats)
        {
            string sql = "UPDATE [dbo].[User_Stats]" +
                "SET ScoreMax = @scoreMax, DeathNumber = @deathNumber, KillNumber = @killNumber, Rank = @rank " +
                "WHERE  Id = @Id";
            var param = new { Id = id, scoreMax = stats.ScoreMax,deathNumber = stats.DeathNumber, killNumber = stats.KillNumber,rank = stats.Rank };
            return await _connection.QueryFirstAsync<User_Stats>(sql, param);
        }

        public async Task<User_Stats> GetStatistic(int id)
        {
            string sql = "SELECT * FROM [dbo].[User_Stats] WHERE Id = @Id";
            var param = new { Id = id };
            return await _connection.QueryFirstAsync<User_Stats>(sql, param);
        }
    }
}
