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


        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            return Json(new { data = await _db.Naves.ToListAsync() });
        }

        [HttpGet("{searchString}")]
        public async Task<IActionResult> GetDet(string searchString) {

            var naves = from m in _db.Naves
                        select m;

            if (!string.IsNullOrEmpty(searchString)) {
                naves = naves.Include(s => s.Nome!.Contains(searchString));
            }

            return Json(new { data = await naves.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            var naveFromDb = await _db.Naves.FirstOrDefaultAsync(u => u.NaveId == id);
            if (naveFromDb == null) {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Naves.Remove(naveFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion
    }
}
