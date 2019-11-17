using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeSheetAppRemodel.EF;
using TimeSheet.Models.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TimeSheetApplication.Service.Controllers
{
    [Route("api/[controller]")]
    public class TimeClockController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        private readonly TimeSheetContext _context;

        public TimeClockController(TimeSheetContext context)
        {
            _context = context;
        }

        // GET: TimeClock
        public async Task<IActionResult> Index()
        {
            return View(await _context.TimeClock.ToListAsync());
        }

        // GET: TimeClock/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeClock = await _context.TimeClock
                .FirstOrDefaultAsync(m => m.ID == id);
            if (timeClock == null)
            {
                return NotFound();
            }

            return View(timeClock);
        }

        // GET: TimeClock/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TimeClock/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ClockIn,InLunch,OutLunch,ClockOut")] TimeClock timeClock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeClock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timeClock);
        }

        // GET: TimeClock/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeClock = await _context.TimeClock.FindAsync(id);
            if (timeClock == null)
            {
                return NotFound();
            }
            return View(timeClock);
        }

        // POST: TimeClock/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ClockIn,InLunch,OutLunch,ClockOut")] TimeClock timeClock)
        {
            if (id != timeClock.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeClock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeClockExists(timeClock.ID))
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
            return View(timeClock);
        }

        // GET: TimeClock/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeClock = await _context.TimeClock
                .FirstOrDefaultAsync(m => m.ID == id);
            if (timeClock == null)
            {
                return NotFound();
            }

            return View(timeClock);
        }

        // POST: TimeClock/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeClock = await _context.TimeClock.FindAsync(id);
            _context.TimeClock.Remove(timeClock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeClockExists(int id)
        {
            return _context.TimeClock.Any(e => e.ID == id);
        }
    }
}
