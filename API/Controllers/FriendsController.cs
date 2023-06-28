using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : Controller
    {
        private readonly IFriendRepository friendservice;

        public FriendsController(IFriendRepository friendService)
        {
            this.friendservice = friendService;
        }


        [HttpGet("GetAllFriends")]
        public async Task<IActionResult> GetAllFriends()
        {
            return Ok(await friendservice.GetAllFriends());
        }

        [HttpGet("GetAllFriendOfUser/{user_id}")]
        public async Task<IActionResult> GetAllFriendsOfUser(int user_id) 
        {
            return Ok(await friendservice.GetAllFriendsOfUser(user_id));
        }

        [HttpPost("AddNewFriend")]
        public IActionResult AddNewFriend(int User_Id,int Friend_Id)
        {
            friendservice.AddNewFriend(User_Id, Friend_Id);
            return Ok();
        }

        [HttpDelete("DeleteFriend/{id}")]
        public IActionResult DeleteFriend(int id) 
        {
            friendservice.DeleteFriend(id);
            return Ok();
        }
    }
}
