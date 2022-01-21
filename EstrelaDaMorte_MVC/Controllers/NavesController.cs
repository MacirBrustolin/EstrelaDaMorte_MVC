using EstrelaDaMorte_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstrelaDaMorte_MVC.Controllers {
    public class NavesController : Controller {

        private readonly ApplicationDbContext _db;
        //[BindProperty]
        //public Nave Nave { get; set; }

        public NavesController(ApplicationDbContext db) {
            _db = db;
        }

        public async Task<IActionResult> Index() {
            return View(await _db.Naves.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var naves = await _db.Naves
                .Include(s => s.PilotoNaves)
                    .ThenInclude(e => e.Pilotos)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.NaveId == id);

            if (naves == null) {
                return NotFound();
            }

            return View(naves);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
        [Bind("Nome, Modelo, Passageiros, Carga, Classe")] Nave nave) {
            try {
                if (ModelState.IsValid) {
                    _db.Add(nave);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            } catch (DbUpdateException /* ex */) {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(nave);
        }
    }
}
