﻿using Microsoft.AspNetCore.Mvc;

namespace artNet.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login ()
        {
            return View();
        }

    }
}
