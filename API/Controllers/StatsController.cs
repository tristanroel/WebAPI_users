using DAL.Entities;
using DAL.Repositories;
using DAL.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : Controller
    {
        private readonly IUser_StatsRepository userstatservice;

        public StatsController(IUser_StatsRepository userStatService)
        {
            this.userstatservice = userStatService;
        }

        [HttpGet("Get_Stats")]
        public async Task<IActionResult> GetStats(int id)
        {
            return Ok(await userstatservice.GetStatistic(id));
        }

        [HttpPost("Set_Stats")]
        public async Task<IActionResult> SetStats(int id, User_Stats stats)
        {
            return Ok(await userstatservice.SetStatistic(id, stats));
        }
    }
}
