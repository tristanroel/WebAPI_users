using BLL.Interfaces;
using DAL.DTO;
using DAL.Entities;
using DAL.Interfaces;
using DAL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userservice;

        public UserController(IUserService userService)
{
            this.userservice = userService;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<UserViewModel>> GetAll(){
            return Ok(userservice.GetAll());
        }

        [HttpGet("GetByid/{id}")]
        public IActionResult GetById(int id){
            return Ok(userservice.GetById(id));
        }

        [HttpGet("GetbyAlias/{alias}")]
        public IActionResult GetByAlias(string alias){
            return Ok(userservice.GetByAlias(alias));
        }

        [HttpGet("GetbyCountry/{country}")]
        public IActionResult GetByCountry(string country)
        {
            return Ok(userservice.GetByCountry(country));
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
                try
                {
                    string jwt = userservice.LoginUser(user);
                    return Ok(jwt);
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            } 
        }
        //[Authorize]
        [HttpPatch("UpdateAlias/{id}")]
        public IActionResult UpdateByAlias(int id, UserAliasUpdateDTO user) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                userservice.UpdateAlias(id, user);
                return Ok();
            }
        }

        [HttpPatch("UpdateAvatar/{id}")]
        public IActionResult UpdateAvatar(int id, UserAvatarUpdateDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                userservice.UpdateAvatar(id, user);
                return Ok();
            }
        }

        [HttpPatch("UpdateCountry/{id}")]
        public IActionResult UpdateCountry(int id, UserCountryUpdateDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                userservice.UpdateCountry(id, user);
                return Ok();
            }
        }

        [HttpPatch("UpdateCredit/{id}")]
        public IActionResult UpdateCredit(int id, UserCreditsUpdateDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                userservice.UpdateCredit(id, user);
                return Ok();
            }
        }

        [HttpPatch("UpdateScore/{id}")]
        public IActionResult UpdateScore(int id, UserScoreUpdateDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                userservice.UpdateScore(id, user);
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
            Console.WriteLine(userservice.DeleteUser(id));
            return userservice.DeleteUser(id) ? Ok() : BadRequest();
        }
    }
}
