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

        [HttpGet("/get-accounts")]
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
