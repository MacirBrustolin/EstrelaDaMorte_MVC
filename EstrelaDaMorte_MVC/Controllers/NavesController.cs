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

        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber) {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["IdSortParm"] = sortOrder == "id_desc" ? "Id" : "id_desc";
            ViewData["NameSortParm"] = sortOrder == "Nome" ? "nome_desc" : "Nome";
            ViewData["ModeloSortParm"] = sortOrder == "Modelo" ? "modelo_desc" : "Modelo";
            ViewData["PassageirosSortParm"] = sortOrder == "Passageiros" ? "passageiros_desc" : "Passageiros";
            ViewData["CargaSortParm"] = sortOrder == "Carga" ? "carga_desc" : "Carga";
            ViewData["ClasseSortParm"] = sortOrder == "Classe" ? "classe_desc" : "Classe";

            if (searchString != null) {
                pageNumber = 1;
            } else {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var naves = from s in _db.Naves
                           select s;
            if (!String.IsNullOrEmpty(searchString)) {
                naves = naves.Where(s => s.Nome.Contains(searchString)
                                       || s.Modelo.Contains(searchString));
            }
            switch (sortOrder) {
                case "Id":
                    naves = naves.OrderBy(s => s.NaveId);
                    break;
                case "id_desc":
                    naves = naves.OrderByDescending(s => s.NaveId);
                    break;
                case "Nome":
                    naves = naves.OrderBy(s => s.Nome);
                    break;
                case "nome_desc":
                    naves = naves.OrderByDescending(s => s.Nome);
                    break;
                case "Modelo":
                    naves = naves.OrderBy(s => s.Modelo);
                    break;
                case "modelo_desc":
                    naves = naves.OrderByDescending(s => s.Modelo);
                    break;
                case "Passageiros":
                    naves = naves.OrderBy(s => s.Passageiros);
                    break;
                case "passageiros_desc":
                    naves = naves.OrderByDescending(s => s.Passageiros);
                    break;
                case "Carga":
                    naves = naves.OrderBy(s => s.Carga);
                    break;
                case "carga_desc":
                    naves = naves.OrderByDescending(s => s.Carga);
                    break;
                case "Classe":
                    naves = naves.OrderBy(s => s.Classe);
                    break;
                case "classe_desc":
                    naves = naves.OrderByDescending(s => s.Classe);
                    break;
                default:
                    naves = naves.OrderBy(s => s.NaveId);
                    break;
            }

            int pageSize = 10;
            return View(await PaginatedList<Nave>.CreateAsync(naves.AsNoTracking(), pageNumber ?? 1, pageSize));
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

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Nome,Modelo,Passageiros,Carga,Classe")] Nave nave) {
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

        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var nave = await _db.Naves.FindAsync(id);
            if (nave == null) {
                return NotFound();
            }
            return View(nave);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id) {
            if (id == null) {
                return NotFound();
            }
            var naveToUpdate = await _db.Naves.FirstOrDefaultAsync(s => s.NaveId == id);
            if (await TryUpdateModelAsync<Nave>(
                naveToUpdate,
                "",
                s => s.Nome, s => s.Modelo, s => s.Passageiros, s => s.Carga, s => s.Classe)) {
                try {
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                } catch (DbUpdateException /* ex */) {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(naveToUpdate);
        }

        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false) {
            if (id == null) {
                return NotFound();
            }

            var nave = await _db.Naves
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.NaveId == id);
            if (nave == null) {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault()) {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(nave);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var nave = await _db.Naves.FindAsync(id);
            if (nave == null) {
                return RedirectToAction(nameof(Index));
            }

            try {
                _db.Naves.Remove(nave);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            } catch (DbUpdateException /* ex */) {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool NaveExists(int id) {
            return _db.Naves.Any(e => e.NaveId == id);
        }
    }
}