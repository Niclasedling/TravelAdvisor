using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Interfaces;
using TravelAdvisor.Infrastructure.Models;

namespace TravelAdvisor.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public readonly IUserService _userService;


        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _logger = logger;
        }



        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _userService.GetById(id);
            return Ok(item);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var item = await _userService.GetAll();
            return Ok(item);



        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var item = await _userService.GetList();
            return Ok(item);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var item = await _userService.Delete(id);
            return Ok(item);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(UserCreateDto newUser)
        {
            var item = await _userService.Create(newUser);
            return Ok(item);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update()
        {
            var item = await _userService.Update();
            return Ok(item);
        }

    }
}
