using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace PORTAL_DE_TI.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Login()
        {      

           return View();
        }


        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            //Sua rotina de autenticação ... 


            //Defina pelo menos um conjunto de claims...
            var claims = new List<Claim>
            {
                //Atributos do usuário ...
                new Claim(ClaimTypes.Name, "romulo.pereira"),
                new Claim(ClaimTypes.Role, "Administrator"),
                new Claim("Nome", "Rômulo Pereirra Felix"),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true
            };

            //Loga de fato
            await HttpContext.SignInAsync(
                  CookieAuthenticationDefaults.AuthenticationScheme,
                  new ClaimsPrincipal(claimsIdentity),
                  authProperties
            );

            //Redireciona para a url desejada...
            return LocalRedirect("/");
        }

        public IActionResult Logout()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
