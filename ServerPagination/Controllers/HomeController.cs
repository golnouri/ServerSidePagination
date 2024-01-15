using Microsoft.AspNetCore.Mvc;
using ServerPagination.Models;
using System.Diagnostics;

namespace ServerPagination.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        //****************************************Mojtaba-Golnouri***********************************
        public class City
        {
            //به کوچک یا بزرگ بودن حروف دقت شود
            public string name { get; set; }
            public int area { get; set; }
        }
        [HttpGet]
        public IActionResult GetData(int pageNumber, int itemsPerPage)
        {
            int count = 20;
            List<City> cities = new List<City>();
            for (int i = 0; i < count; i++)
            {
                cities.Add(new City { name = "شهر " + i, area = i *1000 });
            }
            var dbModel = cities.Skip((pageNumber - 1) * itemsPerPage).Take(itemsPerPage).ToList();
            return Json(dbModel);
        }
        [HttpGet]
        public IActionResult SearchData(string search)
        {
            int count = 20;
            List<City> cities = new List<City>();
            for (int i = 0; i < count; i++)
            {
                cities.Add(new City { name = "شهر " + i, area = i * 1000 });
            }
            if(search != null)
            {
                var filteredCities = cities.Where(c => c.name.Contains(search)).ToList();
                return Json(filteredCities);
            }
            else
            {
                return Json(null);
            }
        }

        public IActionResult Index()
        {
            //تعداد کل داده ها
            ViewBag.GetAllDataCount = 20;
            return View();
        }
        //****************************************Mojtaba-Golnouri***********************************





        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}