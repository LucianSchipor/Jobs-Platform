using Core.Dtos;
using Core.Services;
using DataLayer.Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jobs_Platform.Controllers
{

    [ApiController]
    [Route("api/accounts")]
    [Authorize]
    public class AccountController: ControllerBase
    {
        private readonly AccountService _accountService;
        public AccountController(AccountService accountService)
        {
            this._accountService = accountService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register(RegisterDto payload)
        {
            var result = _accountService.Register(payload);
            if(result != false)
            {
                return Ok("Account has been created.");
            }
            return BadRequest("Account cannot be created");
        }

        [HttpPost("create-admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateAdmin(RegisterDto payload)
        {
          return Ok( _accountService.CreateAdmin(payload));
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(LoginDto payload) { 

           string jwtToken = _accountService.ValidateCredentials(payload);
            if (jwtToken != null)
            {
                return Ok(new {token = jwtToken});
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("login-admin")]
        [AllowAnonymous]

        public IActionResult LoginAsAdmin(LoginDto payload) 
        {
            string jwtToken = _accountService.ValidateAdminCredidentials(payload);
            if(jwtToken != null)
            {
                return Ok(new { token = jwtToken });
            }
            return Unauthorized();
        }

        [HttpGet("get-accounts")]
        [Authorize(Roles ="Admin")]
        public IActionResult GetAccounts()
        {
            var result = _accountService.GetAccounts();
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }


}
