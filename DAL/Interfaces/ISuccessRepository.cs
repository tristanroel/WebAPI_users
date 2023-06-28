using DAL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISuccessRepository
    {
        Task<IEnumerable<Success>> GetAllSuccess();
        Task<Success> GetSuccessById(int id);
        void AddSuccess(AddSuccessDTO success);
        void UpdateSuccess(int id, AddSuccessDTO success);
        void DeleteSuccess(int id);
    }
}
