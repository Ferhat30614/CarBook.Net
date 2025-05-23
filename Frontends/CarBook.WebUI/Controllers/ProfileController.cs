﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            var username = User.Claims.FirstOrDefault(a => a.Type == "Username").Value;
            var aud = User.Claims.FirstOrDefault(a => a.Type == "aud").Value;
            var rol = User.Claims.FirstOrDefault(a => a.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value;

            var token = User.Claims.FirstOrDefault(a => a.Type == "accesToken").Value;
            var Eposta = User.Claims.FirstOrDefault(a => a.Type == "Eposta").Value;

            ViewBag.UserName = username;
            ViewBag.aud = aud;
            ViewBag.rol = rol;
            ViewBag.token = token;
            ViewBag.Eposta = Eposta;


            return View();
        }
    }
}
