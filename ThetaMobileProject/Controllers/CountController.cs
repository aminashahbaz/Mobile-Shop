using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ThetaMobileProject.Controllers
{
    public class CountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}