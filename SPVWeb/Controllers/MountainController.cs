using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPVWeb.Data;
using SPVWeb.Models;

namespace SPVWeb.Controllers
{
    [Authorize]
    public class MountainController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MountainController(ApplicationDbContext db)
        {
            _db = db;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            IEnumerable<Mountain> objectMountainList = _db.Mountains.ToList();
            return View(objectMountainList);
        }
        [AllowAnonymous]
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        {
            return View("Index", await _db.Mountains.Where(j => j.Name.Contains(SearchPhrase)).ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Mountain obj)
        {
            if (obj.Name == obj.TrackCount.ToString())
            {
                ModelState.AddModelError("name", "Trašu skaits nevar būt vienāds ar kalna nosaukumu");
            }
            if (ModelState.IsValid)
            {
                _db.Mountains.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Kalns izveidots veiksmīgi";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }
            var mountainFromDb = _db.Mountains.Find(id);

            if (mountainFromDb == null)
            {
                return NotFound();
            }

            return View(mountainFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Mountain obj)
        {
            if (obj.Name == obj.TrackCount.ToString())
            {
                ModelState.AddModelError("name", "Trašu skaits nevar būt vienāds ar kalna nosaukumu");
            }
            if (ModelState.IsValid)
            {
                _db.Mountains.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Kalns rediģēts veiksmīgi";
                return RedirectToAction("Index");
            }
            return View(obj);

        }
        public IActionResult Delete(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }
            var mountainFromDb = _db.Mountains.Find(id);

            if (mountainFromDb == null)
            {
                return NotFound();
            }

            return View(mountainFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Mountains.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Mountains.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Kalns izdzēsts";
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public IActionResult View(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }
            var mountainFromDb = _db.Mountains.Find(id);

            if (mountainFromDb == null)
            {
                return NotFound();
            }

            return View(mountainFromDb);
        }
    }
}




