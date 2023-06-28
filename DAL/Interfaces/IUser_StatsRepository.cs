using DAL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUser_StatsRepository
    {
        Task<IEnumerable<User_Stats>> GetAllStatistic();
        Task<User_Stats> GetStatById(int id);
        void UpdateStatistics(int id, User_StatsUpdateDTO user);
    }
}
