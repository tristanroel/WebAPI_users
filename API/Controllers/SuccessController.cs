using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuccessController : Controller
    {
        private readonly ISuccessRepository successervice;

        public SuccessController(ISuccessRepository successService){
            this.successervice = successService;
        }

        [HttpGet("GetAllSuccess")]
        public async Task<IActionResult> GetAllSuccess()
        {
            return Ok(await successervice.GetAllSuccess());
        }

        [HttpGet("GetSuccessById")]
        public async Task<IActionResult> GetSuccessById(int id)
        {
            return View(await successervice.GetSuccessById(id));
        }

        [HttpPost("AddSuccess")]
        public IActionResult AddSuccess([FromBody]Success success){
            if (!ModelState.IsValid){
                return BadRequest();
            }
            else{
                successervice.AddSuccess(success);
                return Ok();
            }
        }
    }
}
