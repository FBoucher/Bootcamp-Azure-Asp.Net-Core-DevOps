using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppAspNetCore.Models;

namespace WebAppAspNetCore.Controllers
{
    public class QueueController : Controller
    {
        // GET: Queue/CreateMessage
        public ActionResult CreateMessage()
        {
            return View();
        }

        // POST: Queue/CreateMessage
        [HttpPost]
        public ActionResult CreateMessage(QueueMessageModel message)
        {
            if (ModelState.IsValid)
            {
                // TODO: Insert add message to queue logic here

                return RedirectToAction("Index", "Home");
            }

            return View(message);
        }
    }
}
