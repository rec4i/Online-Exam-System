using Microsoft.AspNetCore.Mvc;

namespace dotnet_5_jwt_refresh_tokens_api_master.Controllers
{
    [Route("")]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        
    }
}