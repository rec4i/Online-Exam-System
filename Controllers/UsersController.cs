using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Services;
using BCryptNet = BCrypt.Net.BCrypt;
using qrmenu.Models.Users;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private DataContext _context;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model, ipAddress());
            //var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);
            RedirectToAction("Login");
            setTokenCookie(response.RefreshToken);
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("JwtToken", response.JwtToken, cookieOptions);
            return Ok(response);
        }


        [Authorize(Role.Admin)]
        [HttpPost("Get_Users_WOP")]
        public IActionResult Get_Users_WOP()
        {
            var x = _userService.Get_Users_WOP();

            return Ok(x);
        }

        [Authorize(Role.Admin)]
        [HttpPost("Get_Users_WP")]
        public IActionResult Get_Users_WP(User y)
        {
            var x = _userService.Get_Users_WP(y);

            return Ok(x);
        }


        [AllowAnonymous]
        [HttpPost("createUser")]
        public IActionResult createUser(RegisterRequest registerRequest)
        {
            if (registerRequest.Password != registerRequest.PasswordRety)
            {
                return BadRequest("Şifreler Aynı Değil");
            }
            else
            {
                _userService.createUser(registerRequest);

                return Ok();
            }

        }
        [Authorize(Role.Admin)]
        [HttpPost("Update_User")]
        public IActionResult Update_User(User registerRequest)
        {

            _userService.Update_User(registerRequest);

            return Ok();
        }

        [Authorize]
        [HttpPost("Get_By_Id_User")]
        public IActionResult Get_By_Id_User(UserTanıma registerRequest)
        {
            var y = Request.HttpContext.Request.Cookies.FirstOrDefault(o => o.Key == "JwtToken").Value;
            registerRequest.Token = y;
            var x= _userService.Get_By_Id_User(registerRequest);
            return Ok(x);
        }
        [Authorize(Role.Admin)]
        [HttpPost("Change_Password")]
        public IActionResult Change_Password(RegisterRequest registerRequest)
        {
            if (registerRequest.Password != registerRequest.PasswordRety)
            {
                return BadRequest("Passwords are not match");
            }
            else
            {
                _userService.Change_Password(registerRequest);

                return Ok();
            }

        }

        [AllowAnonymous]
        [HttpPost("returnuser")]
        public string returnuser(int ıd)
        {
            // add hardcoded test users to db on startup
            var x = _userService.GetById(ıd);
            return x.ToString();
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public IActionResult RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = _userService.RefreshToken(refreshToken, ipAddress());
            setTokenCookie(response.RefreshToken);
            return Ok(response);
        }

        [HttpPost("revoke-token")]
        public IActionResult RevokeToken(RevokeTokenRequest model)
        {
            // accept refresh token in request body or cookie
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Token is required" });

            _userService.RevokeToken(token, ipAddress());
            return Ok(new { message = "Token revoked" });
        }

        [HttpGet]
        [Authorize(Role.Admin)]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
        [HttpPost("GetById")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(Convert.ToInt32(id));
            return Ok(user);
        }

        [HttpGet("{id}/refresh-tokens")]
        public IActionResult GetRefreshTokens(int id)
        {
            var user = _userService.GetById(id);
            return Ok(user.RefreshTokens);
        }

        // helper methods

        private void setTokenCookie(string token)
        {
            // append cookie with refresh token to the http response
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

        private string ipAddress()
        {
            // get source ip address for the current request
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
