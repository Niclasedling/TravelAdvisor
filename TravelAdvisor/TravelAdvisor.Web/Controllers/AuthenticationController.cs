
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using TravelAdvisor.Infrastructure.Interfaces;
using TravelAdvisor.Infrastructure.Services;

namespace TravelAdvisor.Web.Controllers
{
    public class AuthenticationController : Controller
    {
      

        [ApiController]
        [Route("[controller]")]
        public class Authentication : ControllerBase
        {
            private readonly ILogger<AuthenticationController> _logger;

            public readonly IAuthenticationService _authenticationService;
        



            public Authentication(IAuthenticationService authenticationService, ILogger<AuthenticationController> logger)
            {
                _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(AuthenticationService));

                _logger = logger;
          

            }

            ///Authentication class use this interface or use asp.net clas AuthenticationService 



        }
    }
}
