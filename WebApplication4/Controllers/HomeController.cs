using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Localization.Models;
using Microsoft.Extensions.Localization;
using Localization;
using Services.Repository;
using Localization.Utility;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILocalizationServices _localizationService;
        private readonly ILogger<HomeController> _logger;
        //private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IStringLocalizer<CustomStringLocalizer> _eflocalizer;
        public HomeController(ILocalizationServices localizationService,IStringLocalizer<CustomStringLocalizer> eflocalizer,ILogger<HomeController> logger)
        {
            _logger = logger;
           // _localizer = localizer;
            _eflocalizer = eflocalizer;
            _localizationService = localizationService;
        }

        public IActionResult Index()
        {
            var xy = _localizationService.GetAllStrings();
            var x = _eflocalizer.GetAllStrings();
           var y = _eflocalizer["Helloaaaa"];
          //  y[]
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitData(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                return View("Privacy");
            }
            else
            {
                return View("Index");
            }

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}