using EstrelaDaMorte_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstrelaDaMorte_MVC.Controllers {
    public class PilotosController : Controller {

        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Piloto Piloto { get; set; }

        public PilotosController(ApplicationDbContext db) {
            _db = db;
        }

        public IActionResult Index() {
            return View();
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            return Json(new { data = await _db.Pilotos.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            var pilotoFromDb = await _db.Pilotos.FirstOrDefaultAsync(u => u.PilotoId == id);
            if (pilotoFromDb == null) {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Pilotos.Remove(pilotoFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}
