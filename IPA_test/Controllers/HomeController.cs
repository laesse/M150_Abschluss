using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IPA_test.Models;
using IPA_test.Services;
using System.Drawing.Imaging;

namespace IPA_test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHouseService _houseService;

        public HomeController(ILogger<HomeController> logger, IHouseService houseService)
        {
            _logger = logger;
            _houseService = houseService;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new IndexViewModel() { Houses = await _houseService.GetHouses()};
            
            return View(vm); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Details(int Id)
        {

            var house = await _houseService.GetHouseDetails(Id);
            if(house != null)
            {
                string firstImg = house.Images.FirstOrDefault(i => i.IsThub).Src;
                var vm = new DetailsViewModel
                {
                    Id = house.Name,
                    DetailText = house.DetailText.Replace("\n", "\r\n"),
                    PrimaryImage = firstImg,
                    Images = house.Images.Where(img => img.Src != firstImg).Select(img => img.Src).ToList(),
                    Ortschaft = house.Ortschaft,
                    Street = house.Street
                };
                return View(vm);
            }
            else
            {
                return Error();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
