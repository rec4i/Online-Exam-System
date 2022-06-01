using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.Entities;
using Kaynak_Kod.Services;
using System.Threading.Tasks;
using Kaynak_Kod.Models.Users;
using System.Collections.Generic;

namespace Kaynak_Kod.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Şehir_İlçeController : ControllerBase
    {
        private IŞehir_İlçeServices _Şehir_İlçeServices;
        public Şehir_İlçeController(IŞehir_İlçeServices Şehir_İlçeServices)
        {
            _Şehir_İlçeServices = Şehir_İlçeServices;
        }


        [AllowAnonymous]
        [HttpPost("Get_All_City")]
        public async Task<IActionResult> Get_All_City()
        {
            var x = await _Şehir_İlçeServices.Get_All_City();

            return Ok(x);
        }

        [AllowAnonymous]
        [HttpPost("Get_All_Town")]
        public async Task<IActionResult> Get_All_Town()
        {
            var x = await _Şehir_İlçeServices.Get_All_Town();

            return Ok(x);
        }

        [AllowAnonymous]
        [HttpPost("Get_By_CityID_Town")]
        public async Task<IActionResult> Get_By_CityID_Town(City city)
        {
            var x = await _Şehir_İlçeServices.Get_By_CityID_Town(city);

            return Ok(x);
        }


        [AllowAnonymous]
        [HttpPost("Get_By_Word_Town")]
        public IActionResult Get_By_Word_Town(StringRequest city)
        {
            var x = _Şehir_İlçeServices.Get_By_Word_Town(city);

            return Ok(x);
        }

        [AllowAnonymous]
        [HttpPost("Get_By_Word_City")]
        public  IActionResult Get_By_Word_City(StringRequest city)
        {
            var x =  _Şehir_İlçeServices.Get_By_Word_City(city);

            return Ok(x);
        }
       


    }
}