using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppAspNetCore.Models;

namespace WebAppAspNetCore.Controllers
{
    public class RunnerPerformancesController : Controller
    {
        private readonly BootCampContext _context;

        public RunnerPerformancesController(BootCampContext context)
        {
            _context = context;
        }

        // GET: RunnerPerformances
        public async Task<IActionResult> Index()
        {
            return View(await _context.RunnerPerformances.ToListAsync());
        }

        // GET: RunnerPerformances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var runnerPerformance = await _context.RunnerPerformances
                .SingleOrDefaultAsync(m => m.Id == id);
            if (runnerPerformance == null)
            {
                return NotFound();
            }

            return View(runnerPerformance);
        }

        // GET: RunnerPerformances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RunnerPerformances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,FivekmTime")] RunnerPerformance runnerPerformance)
        {
            if (ModelState.IsValid)
            {
                Services.SomeService.TrackCustomStuff(runnerPerformance.FivekmTime);
                _context.Add(runnerPerformance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            } 
            return View(runnerPerformance);
        }

        // GET: RunnerPerformances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var runnerPerformance = await _context.RunnerPerformances.SingleOrDefaultAsync(m => m.Id == id);
            if (runnerPerformance == null)
            {
                return NotFound();
            }
            return View(runnerPerformance);
        }

        // POST: RunnerPerformances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,FivekmTime")] RunnerPerformance runnerPerformance)
        {
            if (id != runnerPerformance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(runnerPerformance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RunnerPerformanceExists(runnerPerformance.Id))
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
            return View(runnerPerformance);
        }

        // GET: RunnerPerformances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var runnerPerformance = await _context.RunnerPerformances
                .SingleOrDefaultAsync(m => m.Id == id);
            if (runnerPerformance == null)
            {
                return NotFound();
            }

            return View(runnerPerformance);
        }

        // POST: RunnerPerformances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var runnerPerformance = await _context.RunnerPerformances.SingleOrDefaultAsync(m => m.Id == id);
            _context.RunnerPerformances.Remove(runnerPerformance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RunnerPerformanceExists(int id)
        {
            return _context.RunnerPerformances.Any(e => e.Id == id);
        }
    }
}
