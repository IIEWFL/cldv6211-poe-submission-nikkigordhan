using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CLDV6221_PoE_Part3.Models;

namespace CLDV6221_PoE_Part3.Controllers
{
    public class ReturnController : Controller
    {
        private readonly RideYouRentContext _context;

        public ReturnController(RideYouRentContext context)
        {
            ViewBag.bLoggedIn = Loggedin.CheckLoggedIn();
            if (Loggedin.bLoggedIn)
            {
                _context = context;
            }
            else
            {
                _context = context;
                _context.TblReturn = null; //set to null to avoid user bypassing the login and going to the page directly

            }
        }

          public async Task<IActionResult> Index(string searchString)
        {
          

            if (_context.TblReturn == null)
            {
                return Problem("Entity set 'CLDV6221_PoE_Part3Context.Return'  is null.");
            }

            var cars = from c in _context.TblReturn.Include(t => t.Car).Include(t => t.Driver).Include(t => t.Inspector)
            select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(s => s.Car.CarNo.Equals(searchString));
            }

            return View(await cars.ToListAsync());
        }

        // GET: Return/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblReturn == null)
            {
                return NotFound();
            }

            var tblReturn = await _context.TblReturn
                .Include(t => t.Car)
                .Include(t => t.Driver)
                .Include(t => t.Inspector)
                .FirstOrDefaultAsync(m => m.ReturnId == id);
            if (tblReturn == null)
            {
                return NotFound();
            }

            return View(tblReturn);
        }

        // GET: Return/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Car, "CarId", "CarNo");
            ViewData["DriverId"] = new SelectList(_context.Driver, "DriverId", "Name");
            ViewData["InspectorId"] = new SelectList(_context.Inspector, "InspectorId", "Name");

            //if (!String.IsNullOrEmpty(dtReturn.ToString))
            //{
                
            //}
            return View();
        }

        // POST: Return/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReturnId,CarId,InspectorId,DriverId,ReturnDate,ElapsedDate,Fine")] TblReturn tblReturn)
        {
            ViewData["CarId"] = new SelectList(_context.Car, "CarId", "CarNo", tblReturn.CarId);
            ViewData["DriverId"] = new SelectList(_context.Driver, "DriverId", "Name", tblReturn.DriverId);
            ViewData["InspectorId"] = new SelectList(_context.Inspector, "InspectorId", "Name", tblReturn.InspectorId);

            //function to calculate the fine also the elapsed date from now.
            DateTime dtReturn = new DateTime();
            dtReturn = tblReturn.ReturnDate;

            DateTime dtToday = new DateTime();
            dtToday = DateTime.Now;
            //Convert.ToInt32(Math.Floor(dblVal))
            int NoOfDays =Convert.ToInt32(Math.Floor(((dtToday - dtReturn).TotalDays)));
            double dFine = 0;

            if (NoOfDays > 0)
            {
                dFine = NoOfDays * 500;
            }
            else
            {
                dFine = 0;
            }

            ViewBag.ElapsedDate = NoOfDays;
            ViewBag.Fine = dFine;
            //determines the cost of the fee depending on the number of elapsed days.


            ModelState.Remove("Car");
            ModelState.Remove("Driver");
            ModelState.Remove("Inspector");
            //removes the above tables from the vaildation


            if (ModelState.IsValid)
            {
                _context.Add(tblReturn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(tblReturn);
        }

        // GET: Return/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblReturn == null)
            {
                return NotFound();
            }

            var tblReturn = await _context.TblReturn.FindAsync(id);
            if (tblReturn == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Car, "CarId", "CarNo", tblReturn.CarId);
            ViewData["DriverId"] = new SelectList(_context.Driver, "DriverId", "Name", tblReturn.DriverId);
            ViewData["InspectorId"] = new SelectList(_context.Inspector, "InspectorId", "Name", tblReturn.InspectorId);
            return View(tblReturn);
        }

        // POST: Return/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReturnId,CarId,InspectorId,DriverId,ReturnDate,ElapsedDate,Fine")] TblReturn tblReturn)
        {
            if (id != tblReturn.ReturnId)
            {
                return NotFound();
            }

            ModelState.Remove("Car");
            ModelState.Remove("Driver");
            ModelState.Remove("Inspector");
            //removes the above tables from the vaildation

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblReturn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblReturnExists(tblReturn.ReturnId))
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
            ViewData["CarId"] = new SelectList(_context.Car, "CarId", "CarNo", tblReturn.CarId);
            ViewData["DriverId"] = new SelectList(_context.Driver, "Name", "DriverId", tblReturn.DriverId);
            ViewData["InspectorId"] = new SelectList(_context.Inspector, "InspectorId", "Name", tblReturn.InspectorId);
            return View(tblReturn);
        }

        // GET: Return/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblReturn == null)
            {
                return NotFound();
            }

            var tblReturn = await _context.TblReturn
                .Include(t => t.Car)
                .Include(t => t.Driver)
                .Include(t => t.Inspector)
                .FirstOrDefaultAsync(m => m.ReturnId == id);
            if (tblReturn == null)
            {
                return NotFound();
            }

            return View(tblReturn);
        }

        // POST: Return/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblReturn == null)
            {
                return Problem("Entity set 'RideYouRentContext.TblReturn'  is null.");
            }
            var tblReturn = await _context.TblReturn.FindAsync(id);
            if (tblReturn != null)
            {
                _context.TblReturn.Remove(tblReturn);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblReturnExists(int id)
        {
          return (_context.TblReturn?.Any(e => e.ReturnId == id)).GetValueOrDefault();
        }
    }
}
// the above code was genertated by Visual Studio Nuget Packet Manager and was adapted to my liking.
