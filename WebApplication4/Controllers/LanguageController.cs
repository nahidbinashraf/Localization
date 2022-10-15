﻿using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace Localization.Controllers
{
    public class LanguageController : Controller
    {
       
        public IActionResult SetLanguage(string culture)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return RedirectToAction("Index","Home");
        }
    }
}
