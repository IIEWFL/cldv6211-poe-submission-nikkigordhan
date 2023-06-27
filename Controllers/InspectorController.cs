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
    public class InspectorController : Controller
    {
        private readonly RideYouRentContext _context;

        public InspectorController(RideYouRentContext context)
        {
            ViewBag.bLoggedIn = Loggedin.CheckLoggedIn();
            if (Loggedin.bLoggedIn)
            {
                _context = context;
            }
            else
            {
                _context = context;
                _context.Inspector = null; //set to null to avoid user bypassing the login and going to the page directly

            }
        }

        // GET: Inspector
        public async Task<IActionResult> Index()
        {

         
            return _context.Inspector != null ? 
                          View(await _context.Inspector.ToListAsync()) :
                          Problem("Entity set 'RideYouRentContext.Inspector'  is null.");
        }

        // GET: Inspector/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inspector == null)
            {
                return NotFound();
            }

            var inspector = await _context.Inspector
                .FirstOrDefaultAsync(m => m.InspectorId == id);
            if (inspector == null)
            {
                return NotFound();
            }

            return View(inspector);
        }

        // GET: Inspector/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inspector/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InspectorId,InspectorNo,Name,Email,Mobile")] Inspector inspector)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inspector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inspector);
        }

        // GET: Inspector/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inspector == null)
            {
                return NotFound();
            }

            var inspector = await _context.Inspector.FindAsync(id);
            if (inspector == null)
            {
                return NotFound();
            }
            return View(inspector);
        }

        // POST: Inspector/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InspectorId,InspectorNo,Name,Email,Mobile")] Inspector inspector)
        {
            if (id != inspector.InspectorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inspector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InspectorExists(inspector.InspectorId))
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
            return View(inspector);
        }

        // GET: Inspector/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inspector == null)
            {
                return NotFound();
            }

            var inspector = await _context.Inspector
                .FirstOrDefaultAsync(m => m.InspectorId == id);
            if (inspector == null)
            {
                return NotFound();
            }

            return View(inspector);
        }

        // POST: Inspector/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inspector == null)
            {
                return Problem("Entity set 'RideYouRentContext.Inspector'  is null.");
            }
            var inspector = await _context.Inspector.FindAsync(id);
            if (inspector != null)
            {
                _context.Inspector.Remove(inspector);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InspectorExists(int id)
        {
          return (_context.Inspector?.Any(e => e.InspectorId == id)).GetValueOrDefault();
        }
    }
}
// the above code was genertated by Visual Studio Nuget Packet Manager and was adapted to my liking.
