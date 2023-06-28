﻿using BLL.Interfaces;
using DAL.DTO;
using DAL.Tools;
using DAL.Interfaces;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtservice;

        public UserService(IUserRepository userRepository, IJwtService jwtservice)
        {
            _userRepository = userRepository;
            _jwtservice = jwtservice;
        }

        public bool DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id) != 0 ? true : false;
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            return _userRepository.GetAll();
        }

        public UserViewModel? GetByAlias(string alias)
        {
            return _userRepository.GetByAlias(alias);
        }

        public UserViewModel? GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public string LoginUser(UserLoginDTO user)
        {

            //_userRepository.LoginUser(user.FromUserLoginDTOToUser())?.ToUserViewModel();
            //return "ok";
            User? u = _userRepository.LoginUser(user.FromUserLoginDTOToUser());
            return _jwtservice.GenerateToken(u);
        }

        public UserViewModel? RegisterUser(UserRegisterDTO user)
        {
            return _userRepository.RegisterUser(user.FromUserRegisterDTOToUser())?.ToUserViewModel();
        }

        public UserViewModel? UpdateUser(int id, UserUpdateDTO user)
        {
            User? u = _userRepository.GetById(id).ToUser();
            if (u is not null)
            {
                u.Alias = user.Alias;
                u.AvatarUrl = user.AvatarUrl;
                u.Email = user.Email;
                u.Passwd = user.Passwd;
                u.Country = user.Country;

                return _userRepository.UpdateUser(u)?.ToUserViewModel();
            }
            else
            {
                return null;
            }
        }

        public UserViewModel? UpdateAlias(int id, UserAliasUpdateDTO user)
        {
            User? u = _userRepository.GetById(id).ToUser();
            if(u is not null)
            {
                u.Alias = user.Alias;
                return _userRepository.UpdateUser(u)?.ToUserViewModel();
            }
            else
            {
                return null;
            }
        }

        public UserViewModel? UpdateAvatar(int id, UserAvatarUpdateDTO user)
        {
            User? u = _userRepository.GetById(id).ToUser();
            if (u is not null)
            {
                u.AvatarUrl = user.AvatarUrl;
                return _userRepository.UpdateUser(u)?.ToUserViewModel();
            }
            else
            {
                return null;
            }
        }

        public UserViewModel? UpdateCountry(int id, UserCountryUpdateDTO user)
        {
            User? u = _userRepository.GetById(id).ToUser();
            if (u is not null)
            {
                u.Country = user.Country;
                return _userRepository.UpdateUser(u)?.ToUserViewModel();
            }
            else
            {
                return null;
            }
        }

        public UserViewModel? UpdateCredit(int id, UserCreditsUpdateDTO user)
        {
            User? u = _userRepository.GetById(id).ToUser();
            if (u is not null)
            {
                u.Credits = user.Credits;
                return _userRepository.UpdateUser(u)?.ToUserViewModel();
            }
            else
            {
                return null;
            }
        }

        public UserViewModel? UpdateScore(int id, UserScoreUpdateDTO user)
        {
            User? u = _userRepository.GetById(id).ToUser();
            if (u is not null)
            {
                u.Score = user.Score;
                return _userRepository.UpdateUser(u)?.ToUserViewModel();
            }
            else
            {
                return null;
            }
        }

    }
}
