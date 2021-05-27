using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Databaze_lab_2;
using Databaze_lab_2.Models;

namespace Databaze_lab_2.Controllers
{
    public class RequestController : Controller
    {
        private readonly TourBaseContext _context;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Request1()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Request1([Bind("A")] Request1_input request)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Request1_res", new { a = request.A });
            }
            return View(request);
        }

        public IActionResult Request1_res(int? a)
        {
            //ViewBag.A = a;
            //var result = _context.
            return View();
        }
    }
}
