using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using admin.Models;
using admin.DapperHelper;
using admin.Eneities;

namespace admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
     
        public IActionResult Index()
        {
            var str = "1111111111111111111111111";
            System.Console.WriteLine(str);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet]
        [Route("/get_user")]
        public IActionResult GetUser() {

            DbHelper db = new DbHelper();
            var user = db.QueryFirst<Users>("select * from user where id = @id",new{id=2});
    
            System.Console.WriteLine(user);
            return Json(user);
        }
    }
}
