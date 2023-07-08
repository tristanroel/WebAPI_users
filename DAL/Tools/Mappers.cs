using DAL.DTO;
using DAL.Entities;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Tools
{
    public static class Mappers
    {
        public static User ToUser(this UserViewModel user)
        {
            return new User
            {
                Id = user.Id,
                Alias = user.Alias,
                Email = user.Email,
                AvatarKey = user.AvatarKey,
                FlagUrl = user.FlagUrl,
                Country = user.Country,
                IsAdmin = user.IsAdmin,
                Credits = user.Credits,
                Score = user.Score
            };
        }

        public static UserViewModel ToUserViewModel(this User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                Alias = user.Alias,
                Email = user.Email,
                AvatarKey = user.AvatarKey,
                FlagUrl = user.FlagUrl,
                Country = user.Country,
                IsAdmin = user.IsAdmin,
                Credits = user.Credits,
                Score = user.Score
            };
        }
        public static User FromUserLoginDTOToUser(this UserLoginDTO user)
        {
            return new User
            {
               Email = user.Email,
               Passwd = user.Passwd,
            };
        }

        public static User FromUserRegisterDTOToUser(this UserRegisterDTO userRegisterDTO)
        {
            return new User
            {
                Alias = userRegisterDTO.Alias,
                Email = userRegisterDTO.Email,
                Passwd = userRegisterDTO.Passwd,
            };
        }

        public static IEnumerable<UserViewModel> ToUserViewModelList(this IEnumerable<User> users) 
        {
            List<UserViewModel> userlist = new List<UserViewModel>();
            foreach (var user in users)
            {
                userlist.Add(user.ToUserViewModel());
            }
            return userlist;
        }
    }
}
