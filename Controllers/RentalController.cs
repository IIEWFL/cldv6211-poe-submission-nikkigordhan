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
    public class RentalController : Controller
    {
        private readonly RideYouRentContext _context;

        public RentalController(RideYouRentContext context)
        {
            ViewBag.bLoggedIn = Loggedin.CheckLoggedIn();
            if (Loggedin.bLoggedIn)
            {
                _context = context;
            }
            else
            {
                _context = context;
                _context.TblRental = null; 
                //set to null to avoid user bypassing the login and going to the page directly

            }
            
        }


        public async Task<IActionResult> Index(string searchString)
        {
          

            if (_context.TblRental == null)
            {
                return Problem("Entity set 'CLDV6221_PoE_Part3Context.Rental'  is null.");
            }

            var cars = from c in _context.TblRental.Include(t => t.Car).Include(t => t.Driver).Include(t => t.Inspector)
                       select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(s => s.Car.CarNo.Equals(searchString));
            }

            return View(await cars.ToListAsync());
        }

        // GET: Rental/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblRental == null)
            {
                return NotFound();
            }

            var tblRental = await _context.TblRental
                .Include(t => t.Car)
                .Include(t => t.Driver)
                .Include(t => t.Inspector)
                .FirstOrDefaultAsync(m => m.RentalId == id);
            if (tblRental == null)
            {
                return NotFound();
            }

            return View(tblRental);
        }

        // GET: Rental/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Car, "CarId", "CarNo");
            ViewData["DriverId"] = new SelectList(_context.Driver, "DriverId", "Name");
            ViewData["InspectorId"] = new SelectList(_context.Inspector, "InspectorId", "Name");
            return View();
        }

        // POST: Rental/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentalId,CarId,InspectorId,DriverId,RentalFee,StartDate,EndDate")] TblRental tblRental)
        {
            ViewData["CarId"] = new SelectList(_context.Car, "CarId", "CarNo", tblRental.CarId);
            ViewData["DriverId"] = new SelectList(_context.Driver, "DriverId", "Name", tblRental.DriverId);
            ViewData["InspectorId"] = new SelectList(_context.Inspector, "InspectorId", "Name", tblRental.InspectorId);

            ModelState.Remove("Car");
            ModelState.Remove("Driver");
            ModelState.Remove("Inspector");
            //removes the above tables from the vaildation

            if (ModelState.IsValid)
            {
                _context.Add(tblRental);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(tblRental);
        }

        // GET: Rental/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblRental == null)
            {
                return NotFound();
            }

            var tblRental = await _context.TblRental.FindAsync(id);
            if (tblRental == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Car, "CarId", "CarNo", tblRental.CarId);
            ViewData["DriverId"] = new SelectList(_context.Driver, "DriverId", "Name", tblRental.DriverId);
            ViewData["InspectorId"] = new SelectList(_context.Inspector, "InspectorId", "Name", tblRental.InspectorId);
            return View(tblRental);
        }

        // POST: Rental/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentalId,CarId,InspectorId,DriverId,RentalFee,StartDate,EndDate")] TblRental tblRental)
        {
            if (id != tblRental.RentalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblRental);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblRentalExists(tblRental.RentalId))
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
            ViewData["CarId"] = new SelectList(_context.Car, "CarId", "CarNo", tblRental.CarId);
            ViewData["DriverId"] = new SelectList(_context.Driver, "DriverId", "Name", tblRental.DriverId);
            ViewData["InspectorId"] = new SelectList(_context.Inspector, "InspectorId", "Name", tblRental.InspectorId);
            return View(tblRental);
        }

        // GET: Rental/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblRental == null)
            {
                return NotFound();
            }

            var tblRental = await _context.TblRental
                .Include(t => t.Car)
                .Include(t => t.Driver)
                .Include(t => t.Inspector)
                .FirstOrDefaultAsync(m => m.RentalId == id);
            if (tblRental == null)
            {
                return NotFound();
            }

            return View(tblRental);
        }

        // POST: Rental/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblRental == null)
            {
                return Problem("Entity set 'RideYouRentContext.TblRental'  is null.");
            }
            var tblRental = await _context.TblRental.FindAsync(id);
            if (tblRental != null)
            {
                _context.TblRental.Remove(tblRental);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblRentalExists(int id)
        {
          return (_context.TblRental?.Any(e => e.RentalId == id)).GetValueOrDefault();
        }
    }
}
// the above code was genertated by Visual Studio Nuget Packet Manager and was adapted to my liking.
