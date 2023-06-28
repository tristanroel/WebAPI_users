using DAL.DTO;
using DAL.Entities;
using DAL.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class User_StatsRepository : IUser_StatsRepository
    {
        private readonly IDbConnection _connection;

        public User_StatsRepository(IDbConnection connection)
        {
            this._connection = connection;
        }

        public void UpdateStatistics(int id, User_StatsUpdateDTO stats)
        {
            string procedure = "UpdateUserStats";
            var param = new 
            { 
                Id = id, 
                stats.LevelMax,
                stats.DeathNumber, 
                stats.KillNumber,
                stats.BonusNumber,
                stats.WeaponNumber,
                stats.BulletDamage,
                stats.BossKill,
                stats.DragonKill,
                stats.SuccessRate,
                stats.Rank
            };
            _connection.Execute(procedure, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<User_Stats> GetStatById(int id)
        {
            string sql = "SELECT * FROM [dbo].[User_Stats] WHERE [User_Stats_Id] = @Id";
            var param = new { Id = id };
            return await _connection.QueryFirstAsync<User_Stats>(sql, param);
        }

        public async Task<IEnumerable<User_Stats>> GetAllStatistic()
        {
            try
            {
                string sql = "SELECT * FROM [dbo].[User_Stats]";
                return await _connection.QueryAsync<User_Stats>(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new List<User_Stats>();
            }
        }
    }
}
