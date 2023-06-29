using Core.Dtos;
using Core.Services;
using DataLayer.Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jobs_Platform.Controllers
{

    [ApiController]
    [Route("api/accounts")]
    public class AccountController: ControllerBase
    {
        private readonly AccountService _accountService;
        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Without authentication
        /// You will register with Employer role. You will have acces to create jobs, but not to see jobs.
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost("register-as-employer")]
        [AllowAnonymous]
        public IActionResult RegisterAsEmployer(RegisterDto payload)
        {
            var result = _accountService.Register(payload, "Employer");
            return result != false ? Ok("Account has been created.") : BadRequest("Account cannot be created");
        }

        /// <summary>
        /// You will register with Applier role. You wil have acces to see jobs, but not to create jobs.
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost("register-as-applier")]
        [AllowAnonymous]
        public IActionResult RegisterAsApplier(RegisterDto payload)
        {
            var result = _accountService.Register(payload, "Applier");

            return result != false ? Ok("Account has been created.") : BadRequest("Account cannot be created");
        }

        [HttpPost("create-admin")]
        public IActionResult CreateAdmin(RegisterDto payload)
        {
          return Ok( _accountService.CreateAdmin(payload));
        }

        /// <summary>
        /// Without authentication
        /// You have to enter account's email and password
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(LoginDto payload) { 

           string jwtToken = _accountService.ValidateCredentials(payload);
            if (jwtToken != null)
            {
                return Ok(new {token = jwtToken});
            }
                return jwtToken != null ? Ok(new { token = jwtToken }):  Unauthorized();
            
        }

        /// <summary>
        /// Requires authentication with an ADMIN account
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost("login-admin")]
        [AllowAnonymous]

        public IActionResult LoginAsAdmin(LoginDto payload) 
        {
            string jwtToken = _accountService.ValidateAdminCredidentials(payload);

            return jwtToken != null ? Ok(new { token = jwtToken }) : Unauthorized();
        }

        /// <summary>
        /// Required authentication with an ADMIN account 
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-accounts")]
        [Authorize(Roles ="Admin")]
        public IActionResult GetAccounts()
        {
            var result = _accountService.GetAccounts();

            return result != null ? Ok(result) : BadRequest();
        }
        [HttpGet("get-admin-accounts")]
        [Authorize(Roles="Admin")]
        public IActionResult GetAdminAccounts() 
        {
            var admins= _accountService.GetAdminAccounts();

            return admins!=null ? Ok(admins) : BadRequest();
        }

    }


}
