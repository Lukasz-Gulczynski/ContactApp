using AutoMapper;
using ContactsApp.Core.Dtos;
using ContactsApp.Service.ActionFilters;
using ContactsApp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApp.API.Controllers
{
    [Route("api/userauthentication")]
    [ApiController]
    public class AuthController : BaseApiController
    {
        public AuthController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) : base(repository, logger, mapper)
        {
        }

        [HttpPost("register")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userRegistration)
        {

            var userResult = await _repository.UserAuthentication.RegisterUserAsync(userRegistration);
            return !userResult.Succeeded ? new BadRequestObjectResult(userResult) : StatusCode(201);
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserLoginDto user)
        {
            return !await _repository.UserAuthentication.ValidateUserAsync(user)
                ? Unauthorized()
                : Ok(new { Token = await _repository.UserAuthentication.CreateTokenAsync() });
        }

    }
}
