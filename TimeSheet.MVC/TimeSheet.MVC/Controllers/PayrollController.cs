using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeSheet.Models.Entities;
using TimeSheet.MVC.WebServiceAccess.Base;
using Newtonsoft.Json;
using TimeSheet.MVC.Models;

namespace TimeSheet.MVC.Controllers
{
    public class PayrollController : Controller
    {
        private readonly TimeSheetMVCContext _context;
        private readonly IWebApiCalls _webApiCalls;
        public PayrollController(IWebApiCalls webApiCalls)
        {
            _webApiCalls = webApiCalls;
        }

        // GET: Payroll
        public async Task<IActionResult> Index()
        {
            return View(await _context.Payroll.ToListAsync());
        }

        // GET: Payroll/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payroll = await _context.Payroll
                .FirstOrDefaultAsync(m => m.ID == id);
            if (payroll == null)
            {
                return NotFound();
            }

            return View(payroll);
        }

        // GET: Payroll/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Payroll/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Salary")] Payroll payroll)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payroll);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(payroll);
        }

        // GET: Payroll/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payroll = await _context.Payroll.FindAsync(id);
            if (payroll == null)
            {
                return NotFound();
            }
            return View(payroll);
        }

        // POST: Payroll/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Salary")] Payroll payroll)
        {
            if (id != payroll.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payroll);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayrollExists(payroll.ID))
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
            return View(payroll);
        }

        // GET: Payroll/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payroll = await _context.Payroll
                .FirstOrDefaultAsync(m => m.ID == id);
            if (payroll == null)
            {
                return NotFound();
            }

            return View(payroll);
        }

        // POST: Payroll/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payroll = await _context.Payroll.FindAsync(id);
            _context.Payroll.Remove(payroll);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PayrollExists(int id)
        {
            return _context.Payroll.Any(e => e.ID == id);
        }
    }
}
