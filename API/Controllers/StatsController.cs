using DAL.DTO;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
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

        [HttpGet("GetAllStats")]
        public async Task<IActionResult> GetAllStats()
        {
            return Ok(await userstatservice.GetAllStatistic());
        }

        [HttpGet("GetStatById/{id}")]
        public async Task<IActionResult> GetStatById(int id)
        {
            return Ok(await userstatservice.GetStatById(id));
        }

        [HttpPut("UpdateStats")]
        public IActionResult UpdateStats(int id, User_StatsUpdateDTO stats)
        {
            userstatservice.UpdateStatistics(id, stats);
            return Ok();
        }
    }
}
