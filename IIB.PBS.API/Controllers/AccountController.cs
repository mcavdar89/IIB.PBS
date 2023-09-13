using IIB.PBS.BL.Abstracts;
using IIB.PBS.Model.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IIB.PBS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IAccountServis _accountServis;
        public AccountController(IAccountServis accountServis)
        {
            _accountServis = accountServis;
        }



        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var result = _accountServis.Login(loginDto);
            return Ok(result);
        }
    }
}
