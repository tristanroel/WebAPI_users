using DAL.DTO;
using DAL.Entities;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserViewModel>? GetAll();
        UserViewModel GetById(int id);
        UserViewModel GetByAlias(string alias);
        User? LoginUser(User user);
        User? RegisterUser(User user);
        User? UpdateUser(User user);
        bool EmailAlreadyUsed(string email);
        int DeleteUser(int id);
    }
}
