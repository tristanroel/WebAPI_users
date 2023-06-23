using DAL.DTO;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userservice;

        public UserController(IUserRepository userService){
            this.userservice = userService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(){
            return Ok(await userservice.GetAll());
        }

        [HttpGet("GetByid/{id}")]
        public async Task<IActionResult> GetById(int id){
            return Ok(await userservice.GetById(id));
        }

        [HttpGet("GetbyAlias/{alias}")]
        public async Task<IActionResult> GetByAlias(string alias){
            return Ok(await userservice.GetByAlias(alias));
        }

        //L'attribut [FromBody] permet de lier les données JSON aux propriétés correspondantes de l'objet UserRegisterDTO passé en paramètre.
        [HttpPost("Register")]
        public IActionResult Register([FromBody] UserRegisterDTO user) {
            if (!ModelState.IsValid){
                return BadRequest();
            }
            else{
            userservice.RegisterUser(user);
            return Ok();            
            }
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserLoginDTO user){    
            if (!ModelState.IsValid){
                 return BadRequest();
            }
            else{
                 userservice.LoginUser(user);
                 return Ok();
            } 
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id,[FromBody]UserUpdateDTO user){
            if (!ModelState.IsValid){
                return BadRequest();
            }
            else{
                userservice.UpdateUser(id, user);
                return Ok();
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteUser(int id){
            userservice.DeleteUser(id);
            return Ok();   
        }
    }
}
