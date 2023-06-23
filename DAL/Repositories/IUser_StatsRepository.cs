using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IUser_StatsRepository
    {
        Task<User_Stats> GetStatistic(int id);
        Task<User_Stats> SetStatistic(int id, User_Stats user);
    }
}
