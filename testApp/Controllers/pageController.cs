using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testApp.Controllers
{
    public class pageController : Controller
    {

        public IActionResult mainpage()
        {
            return View();
        }
        public IActionResult about()
        {
            return View();
        }
        public IActionResult course()
        {
            return View();
        }
       public IActionResult post_register()
        {
            return View();
        }
        
    }
}
