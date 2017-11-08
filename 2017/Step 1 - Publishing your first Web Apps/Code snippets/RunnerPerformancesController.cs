using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppAspNetCore.Models;

namespace WebAppAspNetCore.Controllers
{
    public class RunnerPerformancesController : Controller
    {

       
        public IActionResult Index()
        {
            var runnerPerformances = new List<RunnerPerformance>() {
            new RunnerPerformance(){Id = 1, FirstName = "John", LastName = "Smith", FivekmTime = 15},
            new RunnerPerformance(){Id = 2, FirstName = "Kevin", LastName = "Brady", FivekmTime = 10}
            };

            return View(runnerPerformances);
        }
    }
}
