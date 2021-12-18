using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService; 
        }
        [HttpGet("getbymail")]
        public IActionResult GetByMail(string mail)
        {
            var result = _userService.GetByMail(mail);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }
   
    }
}
