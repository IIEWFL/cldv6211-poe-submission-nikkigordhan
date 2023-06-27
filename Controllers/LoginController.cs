using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CLDV6221_PoE_Part3.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.Tokens;

namespace CLDV6221_PoE_Part3.Controllers
{
    public class LoginController : Controller
    {
        private readonly RideYouRentContext _context;

        public LoginController(RideYouRentContext context)
        {
            _context = context;
        }

        // GET: Login
        public async Task<IActionResult> Index(string Username, string Password)
        {
            
            if (_context.Logins == null)
            {
                return Problem("Entity set 'CLDV6221_PoE_Part3Context.Login'  is null.");
            }

            var login =  from l in _context.Logins.Include(l => l.Inspector)
            select l;

            //default to not logged in 
            Loggedin.bLoggedIn = false; //do not show the menue item 
            ViewBag.bLoggedIn = Loggedin.CheckLoggedIn();

            if ((!String.IsNullOrEmpty(Username)) && (!String.IsNullOrEmpty(Password)))
            {
                
                login = login.Where(s => s.Username.Equals(Username) && s.Password.Equals(Password));

                if (!login.IsNullOrEmpty()) //if is empty then we dont have the user and password in the database ie incorrect 
                {
                    Loggedin.bLoggedIn = true; //do not show the menue item 
                    ViewBag.bLoggedIn = Loggedin.CheckLoggedIn();
                    ViewBag.sError = "Login Successful";
                }
                else
                {
                    Loggedin.bLoggedIn = false; //do not show the menue item 
                    ViewBag.bLoggedIn = Loggedin.CheckLoggedIn();
                    ViewBag.sError = "Login Invalid, Please try again";
                }
            }
            return View();
        }

        // GET: Login/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Logins == null)
            {
                return NotFound();
            }

            var login = await _context.Logins
                .Include(l => l.Inspector)
                .FirstOrDefaultAsync(m => m.LoginId == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // GET: Login/Create
        public IActionResult Create()
        {
            ViewData["InspectorId"] = new SelectList(_context.Inspector, "InspectorId", "InspectorId");
            return View();
        }

        // POST: Login/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoginId,Username,Password,InspectorId")] Login login)
        {
            if (ModelState.IsValid)
            {
                _context.Add(login);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InspectorId"] = new SelectList(_context.Inspector, "InspectorId", "InspectorId", login.InspectorId);
            return View(login);
        }

        // GET: Login/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Logins == null)
            {
                return NotFound();
            }

            var login = await _context.Logins.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }
            ViewData["InspectorId"] = new SelectList(_context.Inspector, "InspectorId", "InspectorId", login.InspectorId);
            return View(login);
        }

        // POST: Login/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoginId,Username,Password,InspectorId")] Login login)
        {
            if (id != login.LoginId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(login);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginExists(login.LoginId))
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
            ViewData["InspectorId"] = new SelectList(_context.Inspector, "InspectorId", "InspectorId", login.InspectorId);
            return View(login);
        }

        // GET: Login/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Logins == null)
            {
                return NotFound();
            }

            var login = await _context.Logins
                .Include(l => l.Inspector)
                .FirstOrDefaultAsync(m => m.LoginId == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // POST: Login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Logins == null)
            {
                return Problem("Entity set 'RideYouRentContext.Logins'  is null.");
            }
            var login = await _context.Logins.FindAsync(id);
            if (login != null)
            {
                _context.Logins.Remove(login);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginExists(int id)
        {
          return (_context.Logins?.Any(e => e.LoginId == id)).GetValueOrDefault();
        }
    }
}
// the above code was genertated by Visual Studio Nuget Packet Manager and was adapted to my liking.
