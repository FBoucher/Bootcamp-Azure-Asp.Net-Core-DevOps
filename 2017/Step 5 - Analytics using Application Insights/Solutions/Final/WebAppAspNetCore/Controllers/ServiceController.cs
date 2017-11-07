using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ApplicationInsights;

namespace WebAppAspNetCore.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                //Services.SomeService.ThrowAnExceptionPlease();
                Services.SomeService.SomeWorkWithDependency();
            }
            catch (Exception ex)
            {
                var client = new TelemetryClient();
                client.TrackException(ex);
            }
            return View();
        }
    }
}