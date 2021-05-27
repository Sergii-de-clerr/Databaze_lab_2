using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Databaze_lab_2;
using System.Text.RegularExpressions;

namespace Databaze_lab_2.Controllers
{
    public class TouristsController : Controller
    {
        private readonly TourBaseContext _context;

        public TouristsController(TourBaseContext context)
        {
            _context = context;
        }

        // GET: Tourists
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tourists.ToListAsync());
        }

        // GET: Tourists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourist = await _context.Tourists
                .FirstOrDefaultAsync(m => m.TouristId == id);
            if (tourist == null)
            {
                return NotFound();
            }

            return View(tourist);
        }

        // GET: Tourists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tourists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("TouristId,TouristName,BirthDate,EmailAdress")] Tourist tourist)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(tourist);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(tourist);
        //}

        public async Task<IActionResult> Create([Bind("TouristId,TouristName,BirthDate,EmailAdress")] Tourist tourist)
        {
            if (string.IsNullOrEmpty(tourist.EmailAdress))
            {
                ModelState.AddModelError("EmailAdress", "Це поле повинно бути заповнене");
            }
            else
            {
                Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
                bool isValidEmail = regex.IsMatch(tourist.EmailAdress);
                if (!isValidEmail)
                {
                    ModelState.AddModelError("EmailAdress", "Невірний запис e-mail адреси");
                }
            }

            DateTime t = Convert.ToDateTime("01.01.1920");
            if (tourist.BirthDate < t)
            {
                ModelState.AddModelError("BirthDate", "Некоректний вік");
            }

            if (ModelState.IsValid)
            {
                _context.Add(tourist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tourist);
        }

        // GET: Tourists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourist = await _context.Tourists.FindAsync(id);
            if (tourist == null)
            {
                return NotFound();
            }
            return View(tourist);
        }

        // POST: Tourists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("TouristId,TouristName,BirthDate,EmailAdress")] Tourist tourist)
        //{
        //    if (id != tourist.TouristId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(tourist);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TouristExists(tourist.TouristId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(tourist);
        //}

        public async Task<IActionResult> Edit(int id, [Bind("TouristId,TouristName,BirthDate,EmailAdress")] Tourist tourist)
        {
            if (string.IsNullOrEmpty(tourist.EmailAdress))
            {
                ModelState.AddModelError("EmailAdress", "Це поле повинно бути заповнене");
            }
            else
            {
                Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
                bool isValidEmail = regex.IsMatch(tourist.EmailAdress);
                if (!isValidEmail)
                {
                    ModelState.AddModelError("EmailAdress", "Невірний запис e-mail адреси");
                }
            }

            if (id != tourist.TouristId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tourist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TouristExists(tourist.TouristId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tourist);
        }

        // GET: Tourists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourist = await _context.Tourists
                .FirstOrDefaultAsync(m => m.TouristId == id);
            if (tourist == null)
            {
                return NotFound();
            }

            return View(tourist);
        }

        // POST: Tourists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tourBaseContext = _context.Vouchers.Where(v => v.TouristId == id).Include(v => v.Tour).Include(v => v.Tourist);
            var cont = tourBaseContext.ToList();
            var tourist = await _context.Tourists.FindAsync(id);
            _context.Tourists.Remove(tourist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TouristExists(int id)
        {
            return _context.Tourists.Any(e => e.TouristId == id);
        }
    }
}
