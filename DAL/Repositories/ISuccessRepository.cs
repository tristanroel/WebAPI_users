using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface ISuccessRepository
    {
        Task<IEnumerable<Success>> GetAllSuccess();
        Task<Success> GetSuccessById(int id);
        void AddSuccess(Success success);
        void UpdateSuccess(int id);
        Task DeleteSuccess(int id);
    }
}
