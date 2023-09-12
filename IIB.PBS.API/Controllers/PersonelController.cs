using IIB.PBS.BL.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IIB.PBS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        private readonly IPersonelServis _personelServis;
        public PersonelController(IPersonelServis personelServis)
        {
            _personelServis = personelServis;
        }

        [HttpGet("get/{isim?}")]
        public IActionResult Get(string? isim)
        {
            var list = _personelServis.List(isim);
            return Ok(list);


            //return Ok("Personel controllerı");
        }


    }
}
