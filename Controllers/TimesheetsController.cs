using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Timesheet_Project.Models;
using Timesheet_Project.ViewModel;

namespace Timesheet_Project.Controllers
{
    public class TimesheetsController : Controller
    {
        private readonly TimesheetDBContext _context;
        //private readonly ITimesheetService _timesheetService;
        public TimesheetsController(TimesheetDBContext context)
        {
            _context = context;
        }

        //GET: Timesheets
        public async Task<IActionResult> Index()
        {
            var timesheetDBContext = _context.Timesheets.Include(t => t.Emp);
            return View(await timesheetDBContext.ToListAsync());
        }
        //public async Task<IActionResult> Create(int? timesheet_id)
        //{
        //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //var emp = _hrmUtilService.GetEmployeeByUserId(userId);

        //if (EmpId != null)
        //{
        //if (timesheet_id.HasValue && timesheet_id < 1)
        //{
        //    ViewBag.Message = TempData["Message"];
        //    return View(null);
        //}
        //else
        //{
        //    //ViewBag.emp_number = emp.EmpNumber;
        //    var timesheet = await _timesheetService.GetEmployeeLastTimesheet(emp.EmpNumber);
        //    var timesheetModel = new TimesheetModel
        //    {
        //        Timesheet = timesheet
        //    };
        //    if (timesheet == null)
        //    {
        //        timesheetModel.month = DateTime.Now.Month;
        //        timesheetModel.year = DateTime.Now.Year;
        //    }
        //    else
        //    {
        //        timesheetModel.month = timesheet.StartDate.Month;
        //        timesheetModel.year = timesheet.StartDate.Year;
        //    }
        //    ViewBag.Message = TempData["Message"];
        //    return View(timesheetModel);
        //}
        //}
        //return NotFound();
        //}

        // GET: Timesheets/Create
        public IActionResult Create()
        {
            ViewData["EmpId"] = new SelectList(_context.Employees, "Id", "Id");
            return View();
        }

        [HttpPost]
        //[PermissionFilter(permission = "timesheet.mytimesheet")]
        public async Task<ActionResult> Create(IFormCollection form_collection)
        {
            var year = Convert.ToInt32(form_collection["year"]);
            var month = Convert.ToInt32(form_collection["month"]);
            var start_date = new DateTime(year, month, 1);
            var end_date = new DateTime(year, month, DateTime.DaysInMonth(year, month));

            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var emp = _hrmUtilService.GetEmployeeByUserId(userId);

            var timesheet = await _context.Timesheets.Include(m => m.TimesheetItems)
            .OrderByDescending(m => m.TimesheetId)
            .FirstOrDefaultAsync(m => m.EmpId == 1 && m.StartDate == start_date && m.EndDate == end_date);


            //var timesheet = await _timesheetService.GetEmployeeTimesheetByDates(start_date, end_date, emp.EmpNumber);
            var timesheetModel = new TimesheetModel
            {
                Timesheet = timesheet
            };
            if (timesheet == null)
            {
                timesheetModel.month = month;
                timesheetModel.year = year;
            }
            else
            {
                timesheetModel.month = timesheet.StartDate.Month;
                timesheetModel.year = timesheet.StartDate.Year;
            }
            return View(timesheetModel);
        }

        // GET: Timesheets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Timesheets == null)
            {
                return NotFound();
            }

            var timesheet = await _context.Timesheets
                .Include(t => t.Emp)
                .FirstOrDefaultAsync(m => m.TimesheetId == id);
            if (timesheet == null)
            {
                return NotFound();
            }

            return View(timesheet);
        }

    

        //// POST: Timesheets/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("TimesheetId,EmpId,State,StartDate,EndDate,CreatedAt")] Timesheet timesheet)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(timesheet);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["EmpId"] = new SelectList(_context.Employees, "Id", "Id", timesheet.EmpId);
        //    return View(timesheet);
        //}

        // GET: Timesheets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Timesheets == null)
            {
                return NotFound();
            }

            var timesheet = await _context.Timesheets.FindAsync(id);
            if (timesheet == null)
            {
                return NotFound();
            }
            ViewData["EmpId"] = new SelectList(_context.Employees, "Id", "Id", timesheet.EmpId);
            return View(timesheet);
        }

        // POST: Timesheets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimesheetId,EmpId,State,StartDate,EndDate,CreatedAt")] Timesheet timesheet)
        {
            if (id != timesheet.TimesheetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timesheet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimesheetExists(timesheet.TimesheetId))
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
            ViewData["EmpId"] = new SelectList(_context.Employees, "Id", "Id", timesheet.EmpId);
            return View(timesheet);
        }

        // GET: Timesheets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Timesheets == null)
            {
                return NotFound();
            }

            var timesheet = await _context.Timesheets
                .Include(t => t.Emp)
                .FirstOrDefaultAsync(m => m.TimesheetId == id);
            if (timesheet == null)
            {
                return NotFound();
            }

            return View(timesheet);
        }

        // POST: Timesheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Timesheets == null)
            {
                return Problem("Entity set 'TimesheetDBContext.Timesheets'  is null.");
            }
            var timesheet = await _context.Timesheets.FindAsync(id);
            if (timesheet != null)
            {
                _context.Timesheets.Remove(timesheet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimesheetExists(int id)
        {
          return (_context.Timesheets?.Any(e => e.TimesheetId == id)).GetValueOrDefault();
        }
    }
}
