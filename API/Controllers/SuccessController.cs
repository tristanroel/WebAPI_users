using DAL.DTO;
using DAL.Entities;
using DAL.Interfaces;
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
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                return Ok(await successervice.GetAllSuccess());
            }
        }

        [HttpGet("GetSuccessById/{id}")]
        public async Task<IActionResult> GetSuccessById(int id)
        {
            return Ok(await successervice.GetSuccessById(id));
        }

        [HttpPost("AddSuccess")]
        public IActionResult AddSuccess([FromBody]AddSuccessDTO success){
            if (!ModelState.IsValid){
                return BadRequest();
            }
            else{
                successervice.AddSuccess(success);
                return Ok();
            }
        }

        [HttpPut("EditSuccess")]
        public IActionResult UpdateSuccess(int id,[FromBody]AddSuccessDTO success){
            if (!ModelState.IsValid){
                return BadRequest();
            }
            else{
                successervice.UpdateSuccess(id, success);
                return Ok();
            }
        }

        [HttpDelete("DeleteSuccess")]
        public IActionResult DeleteSuccess(int id) 
        {
            successervice.DeleteSuccess(id);
            return Ok();
        }
    }
}
