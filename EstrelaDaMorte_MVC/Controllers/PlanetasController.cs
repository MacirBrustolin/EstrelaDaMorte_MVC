using EstrelaDaMorte_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstrelaDaMorte_MVC.Controllers {
    public class PlanetasController : Controller {

        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Planeta Planeta { get; set; }

        public PlanetasController(ApplicationDbContext db) {
            _db = db;
        }

        public IActionResult Index() {
            return View();
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            return Json(new { data = await _db.Planetas.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            var planetaFromDb = await _db.Planetas.FirstOrDefaultAsync(u => u.PlanetaId == id);
            if (planetaFromDb == null) {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Planetas.Remove(planetaFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}
