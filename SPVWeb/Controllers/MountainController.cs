using Microsoft.AspNetCore.Mvc;
using SPVWeb.Data;
using SPVWeb.Models;

namespace SPVWeb.Controllers
{
    public class MountainController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MountainController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Mountain> objectMountainList = _db.Mountains.ToList();
            return View(objectMountainList);
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
                ModelState.AddModelError("name", "The display order cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Mountains.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Mountain created successfully";
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
                ModelState.AddModelError("name", "The display order cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Mountains.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Mountain updated successfully";
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
            TempData["success"] = "Mountain deleted successfully";
            return RedirectToAction("Index");
        }
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




