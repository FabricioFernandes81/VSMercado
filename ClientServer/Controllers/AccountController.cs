using ClientServer.DTOs;
using ClientServer.Services;
using ClientServer.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientServer.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<TokenResponse>> Registro([FromForm]RegistroDTO registro) 
        {
           var result = await _accountService.ResgistrarLoja(registro);
          
            return Ok(result);
        }

    }
}
