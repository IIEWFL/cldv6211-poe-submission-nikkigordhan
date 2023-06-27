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
    public class CarController : Controller
    {
        private readonly RideYouRentContext _context;

        public CarController(RideYouRentContext context)
        {
            ViewBag.bLoggedIn = Loggedin.CheckLoggedIn();
            if (Loggedin.bLoggedIn)
            {
                _context = context;
            }
            else
            {
                _context = context;
                _context.Car = null; 
                //set to null to avoid user bypassing the login and going to the page directly

            }
        }

        

        // GET: Car
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Car == null)
            {
                return Problem("Entity set 'CLDV6221_PoE_Part3Context.Car'  is null.");
            }

            var cars = from c in _context.Car.Include(c => c.CarBodyType).Include(c => c.CarMake)
                       select c;

            return View(await cars.ToListAsync());
        }

        // GET: Car/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .Include(c => c.CarBodyType)
                .Include(c => c.CarMake)
                .FirstOrDefaultAsync(m => m.CarId == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Car/Create
        public IActionResult Create()
        {
            ViewData["CarBodyTypeId"] = new SelectList(_context.CarBodyTypes, "CarBodyTypeId", "Description");
            ViewData["CarMakeId"] = new SelectList(_context.CarMakes, "CarMakeId", "Description");
            return View();
        }

        // POST: Car/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarId,CarNo,CarMakeId,CarBodyTypeId,Model,KilometersTravelled,ServiceKilometers,Available")] Car car)
        {
            ViewData["CarBodyTypeId"] = new SelectList(_context.CarBodyTypes, "CarBodyTypeId", "Description", car.CarBodyTypeId);
            ViewData["CarMakeId"] = new SelectList(_context.CarMakes, "CarMakeId", "Description", car.CarMakeId);

            ModelState.Remove("CarMake");
            ModelState.Remove("CarBodyType");
            //removes the above tables from the validation

            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Car/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["CarBodyTypeId"] = new SelectList(_context.CarBodyTypes, "CarBodyTypeId", "Description", car.CarBodyTypeId);
            ViewData["CarMakeId"] = new SelectList(_context.CarMakes, "CarMakeId", "Description", car.CarMakeId);
            return View(car);
        }

        // POST: Car/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarId,CarNo,CarMakeId,CarBodyTypeId,Model,KilometersTravelled,ServiceKilometers,Available")] Car car)
        {
            if (id != car.CarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.CarId))
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
            ViewData["CarBodyTypeId"] = new SelectList(_context.CarBodyTypes, "CarBodyTypeId", "Description", car.CarBodyTypeId);
            ViewData["CarMakeId"] = new SelectList(_context.CarMakes, "CarMakeId", "Description", car.CarMakeId);
            return View(car);
        }

        // GET: Car/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .Include(c => c.CarBodyType)
                .Include(c => c.CarMake)
                .FirstOrDefaultAsync(m => m.CarId == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Car == null)
            {
                return Problem("Entity set 'RideYouRentContext.Cars'  is null.");
            }
            var car = await _context.Car.FindAsync(id);
            if (car != null)
            {
                _context.Car.Remove(car);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
          return (_context.Car?.Any(e => e.CarId == id)).GetValueOrDefault();
        }
    }
}
// the above code was genertated by Visual Studio Nuget Packet Manager and was adapted to my liking.