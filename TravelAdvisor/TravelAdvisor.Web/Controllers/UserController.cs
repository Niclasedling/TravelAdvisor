using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Interfaces;
using TravelAdvisor.Infrastructure.Migrations.HelperClasses;
using TravelAdvisor.Infrastructure.Migrations.Models;
using TravelAdvisor.Infrastructure.Models;
using TravelAdvisor.Infrastructure.Services;

namespace TravelAdvisor.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public readonly IUserService _userService;
        private readonly UserService _userRepository;



        public UserController(IUserService userService, ILogger<UserController> logger, UserService userRepository)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _logger = logger;
            _userRepository = userRepository;

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

        [HttpPost("Login")]
        //public async Task<IActionResult> Login(Login model)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        //if (_userRepository.GetByEmailAndPassword(model.Email, model.Password) != null)
        //        //{
        //        //    await HttpContext.SignInAsync(
        //        //     CookieAuthenticationDefaults.AuthenticationScheme,
        //        //     new ClaimsPrincipal(_userRepository.Authenticate(model.Email)));

        //        //    return new JsonResult(model.Email);
        //        //}
        //        //else
        //        //{
        //        //    return new JsonResult("Wrong Email or password");

        //        //}

        //    }
        //    return new JsonResult(model);
        //}

        //!!!!!!!!!!!!!!!!!!!!!Registrering!!!!!!!!!!!!!!!!!!!

        [HttpPost("Register")]
        //public async Task<IActionResult> Register(Register model)
        //{

        //    if (_userRepository.GetByEmail(model.Email) == null)
        //    {
        //        _userRepository.Add(new User { FirstName = model.FirstName, LastName = model.LastName, Email = model.Email, Password = model.Password });

        //        return Ok($"{ model.Email } is success");

        //        //return new JsonResult($"{ model.Email } is success");
        //    }
        //    else
        //    {
        //        return Ok("User with this email already exists ");

        //        //return new JsonResult("User with this email already exists ");
        //    }

        //}
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return new JsonResult("Thanks for your visit!");
        }

    }
}
