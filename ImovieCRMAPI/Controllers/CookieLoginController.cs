using Antra.IMovie.Core.Contracts.Service;
using Antra.IMovie.Core.Model;
using Antra.IMovie.Infrascruture.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IMovieCRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookieLoginController : ControllerBase
    {
        private readonly ICookieLoginService cookieService;

        public CookieLoginController(ICookieLoginService cookieService) {
            this.cookieService = cookieService;
        }
        [HttpPost("CookieLogin")]
        public async Task<IActionResult> RegularUserLogin(CookieUserLoginModel model) {
            var user = await cookieService.cookieLogin(model);
            if (user == null)
            {
                return Unauthorized(new { Message = "Invalid Username and password" });
            }
            else {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.FirstName),
                    new Claim("FullName", user.LastName),
                    new Claim(ClaimTypes.Role, "Regular")
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return Ok(new { Message = "cookie login success" });
            }
        }
        [HttpDelete]
        public void logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        [HttpGet("NoLogin")]
        public string noLogin()
        {
            return "未登入";
        }
    }
}
