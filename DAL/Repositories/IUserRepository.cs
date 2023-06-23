using DAL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> GetByAlias(string alias);
        void LoginUser(UserLoginDTO user);
        void RegisterUser(UserRegisterDTO user);
        void UpdateUser(int id,UserUpdateDTO user);
        Task DeleteUser(int id);
    }
}
