using DAL.Entities;
using DAL.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class SuccessService : ISuccessRepository
    {
        private readonly IDbConnection _connection;

        public SuccessService(IDbConnection connection)
        {
            this._connection = connection;
        }

        public void AddSuccess(Success s)
        {
            string sql = "INSERT INTO [dbo].[Success]([Title], [Description], [ScoreMax]," +
                "[DeathNumber], [KillNumber], [BonusNumber], [WeaponNumber], [BulletDamage]," +
                "[BossKill], [DragonKill], [SuccessRate], [Rank])" +
                "VALUES (@Title ,@Description, @ScoreMax,@DeathNumber,@KillNumber,@BonusNumber," +
                "@WeaponNumber,@BulletDamage,@BossKill,@DragonKill,@SuccessRate,@Rank)";
            var param = new 
            { 
                Title = s.Title, Description = s.Description, ScoreMax = s.ScoreMax,
                DeathNumber = s.DeathNumber, KillNumber = s.KillNumber, BonusNumber = s.BonusNumber,
                WeaponNumber = s.WeaponNumber, BulletDamage = s.BulletDamage, BossKill = s.BossKill,
                DragonKill = s.DragonKill,SuccessRate = s.SuccessRate,Rank = s.Rank
            };
            _connection.QueryAsync(sql, param);
        }

        public async Task DeleteSuccess(int id)
        {
            string sql = "DELETE FROM [dbo].[Success] WHERE @ID = Id";
            var param = new { ID = id };
            await _connection.QueryAsync(sql, param);
        }

        public async Task<IEnumerable<Success>> GetAllSuccess()
        {
            string sql = "SELECT * FROM [dbo].[Success]";
            return await _connection.QueryAsync<Success>(sql);
        }

        public async Task<Success> GetSuccessById(int id)
        {
            string sql = "SELECT * FROM [dbo].[Success] WHERE Id = @Id";
            var param = new { Id = id };
            return await _connection.QueryFirstAsync<Success>(sql, param);
        }

        public void UpdateSuccess(int id)
        {
            throw new NotImplementedException();
        }
    }
}
