using DAL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IFriendRepository
    {
        void AddNewFriend(int User_Id,int Friend_Id);
        Task<IEnumerable<Friend>> GetAllFriends();
        Task<IEnumerable<Friend>> GetAllFriendsOfUser(int User_Id);
        void DeleteFriend(int id);
    }
}
