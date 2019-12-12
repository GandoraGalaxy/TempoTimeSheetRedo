using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeSheet.MVC.Models;
using TimeSheet.MVC.WebServiceAccess.Base;
using Newtonsoft.Json;
using TimeSheet.Models.Entities;

namespace TimeSheet.MVC.Controllers
{
    public class TimeClockController : Controller
    {
        private readonly TimeSheetMVCContext _context;
        private readonly IWebApiCalls _webApiCalls;
        public TimeClockController(IWebApiCalls webApiCalls)
        {
            _webApiCalls = webApiCalls;
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
        public async Task<IActionResult> Create([Bind("ID,ClockIn,InLunch,OutLunch,ClockOut,TotalHrs")] TimeClock timeClock)
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
        public async Task<IActionResult> Edit(int id, [Bind("ID,ClockIn,InLunch,OutLunch,ClockOut,TotalHrs")] TimeClock timeClock)
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
