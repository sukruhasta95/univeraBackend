using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("addUser")]
        public IActionResult Add(User user)
        {
            _userService.Add(user); 
            return Ok();
        }
        [HttpPost("updateUser")]
        public IActionResult Update (User user)
        {
            _userService.Update(user);
            return Ok();
        }
        [HttpPost("deleteUser")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }

        [HttpGet ("getAllUser")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            return Ok(result);
        }
        [HttpGet("getByUserId")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
            return Ok(result);
        }


    }
}
