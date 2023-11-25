using _2WebApiService.DTOs;
using _2WebApiService.Interfaces;
using _2WebApiService.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _2WebApi.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUser userService;

        public UserController(IUser userservice)
        {
            userService = userservice;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAll()
        => Ok(await userService.GetAllAsync());

        [HttpGet("{id:long}")]
        public async Task<ActionResult<UserViewModel>> GetAsync([FromRoute] long id)
        {
            var usergetid = await userService.GetAsync(id);

            return usergetid;
        }
        

        [HttpPost("createuser")]
        public async Task<ActionResult<UserViewModel>> CreateAsync([FromForm] UserCreationDto userCreationDto)
        {
            var usercreate = await userService.CreateAsync(userCreationDto);

            return usercreate;
        }

    }
}
