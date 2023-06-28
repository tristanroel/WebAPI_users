using DAL.DTO;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<UserViewModel> GetAll();
        public UserViewModel? GetById(int id);
        public UserViewModel? GetByAlias(string alias);
        public UserViewModel? UpdateScore(int id, UserScoreUpdateDTO user);
        public UserViewModel? UpdateAlias(int id, UserAliasUpdateDTO user);
        public UserViewModel? UpdateCountry(int id, UserCountryUpdateDTO user);
        public UserViewModel? UpdateAvatar(int id, UserAvatarUpdateDTO user);
        public UserViewModel? UpdateCredit(int id, UserCreditsUpdateDTO user);
        public string LoginUser(UserLoginDTO user);
        public UserViewModel? RegisterUser(UserRegisterDTO user);
        public UserViewModel? UpdateUser(int id, UserUpdateDTO user);
        public bool DeleteUser(int id);
    }
}
