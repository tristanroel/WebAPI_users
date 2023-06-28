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
    public class SuccessRepository : ISuccessRepository
    {
        private readonly IDbConnection _connection;

        public SuccessRepository(IDbConnection connection)
        {
            this._connection = connection;
        }

        public void AddSuccess(AddSuccessDTO s)
        {
            string sql = "INSERT INTO [dbo].[Success]([Title], [Description], [ScoreMax]," +
                "[LevelMax], [DeathNumber], [KillNumber], [BonusNumber], [WeaponNumber], [BulletDamage]," +
                "[BossKill], [DragonKill], [SuccessRate], [Rank])" +
                "VALUES (@Title ,@Description, @ScoreMax, @LevelMax ,@DeathNumber,@KillNumber,@BonusNumber," +
                "@WeaponNumber,@BulletDamage,@BossKill,@DragonKill,@SuccessRate,@Rank)";
            var param = new 
            { 
                Title = s.Title, 
                Description = s.Description, 
                ScoreMax = s.ScoreMax,
                LevelMax = s.LevelMax,
                DeathNumber = s.DeathNumber, 
                KillNumber = s.KillNumber, 
                BonusNumber = s.BonusNumber,
                WeaponNumber = s.WeaponNumber, 
                BulletDamage = s.BulletDamage, 
                BossKill = s.BossKill,
                DragonKill = s.DragonKill,
                SuccessRate = s.SuccessRate,
                Rank = s.Rank
            };
            _connection.Query(sql, param);
        }

        public void DeleteSuccess(int id)
        {
            string sql = "DELETE FROM [dbo].[Success] WHERE @ID = Id";
            var param = new { ID = id };
            _connection.QueryFirstAsync(sql, param);
        }

        public async Task<IEnumerable<Success>> GetAllSuccess()
        {
            try
            {
                string sql = "SELECT * FROM [dbo].[Success]";
                return await _connection.QueryAsync<Success>(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Success[0];
            }
        }

        public async Task<Success> GetSuccessById(int id)
        {
            string sql = "SELECT * FROM [dbo].[Success] WHERE @Id = Id";
            var param = new { Id = id };
            return await _connection.QueryFirstAsync<Success>(sql, param);
        }
        //public void SetSuccessDTO()
        //{
        //    try
        //    {
        //        string sql =
        //            "SELECT @Title = [Title]," +
        //            "@Description = [Description]," +
        //            "@ScoreMax = [ScoreMax]," +
        //            "@LevelMax = [LevelMax]," +
        //            "@DeathNumber = [DeathNumber]," +
        //            "@KillNumber = [KillNumber]," +
        //            "@BonusNumber = [BonusNumber]," +
        //            "@WeaponNumber = [WeaponNumber]," +
        //            "@BulletDamage = [BulletDamage]," +
        //            "@BossKill = [BossKill]," +
        //            "@DragonKill = [DragonKill]," +
        //            "@SuccessRate = [SuccessRate]," +
        //            "@Rank = [Rank]" +
        //            "from [dbo].[Success] WHERE[Id] = @Id";
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        public void UpdateSuccess(int id, AddSuccessDTO s)
        {
            try
            {
                string sql =
                "UPDATE[dbo].[Success]" +
                "SET[Title] = @Title," +
                "[Description] = @Description," +
                "[ScoreMax] = @ScoreMax," +
                "[LevelMax] = @LevelMax," +
                "[DeathNumber] = @DeathNumber," +
                "[KillNumber] = @KillNumber," +
                "[BonusNumber] = @BonusNumber," +
                "[WeaponNumber] = @WeaponNumber," +
                "[BulletDamage] = @BulletDamage," +
                "[BossKill] = @BossKill," +
                "[DragonKill] = @DragonKill," +
                "[SuccessRate] = @SuccessRate," +
                "[Rank] = @Rank WHERE[Id] = @Id";

                var param = new
                {
                    Id = id,
                    Title = s.Title,
                    Description = s.Description,
                    ScoreMax = s.ScoreMax,
                    LevelMax = s.LevelMax,
                    DeathNumber = s.DeathNumber,
                    KillNumber = s.KillNumber,
                    BonusNumber = s.BonusNumber,
                    WeaponNumber = s.WeaponNumber,
                    BulletDamage = s.BulletDamage,
                    BossKill = s.BossKill,
                    DragonKill = s.DragonKill,
                    SuccessRate = s.SuccessRate,
                    Rank = s.Rank
                };
                _connection.QueryFirst(sql, param);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
