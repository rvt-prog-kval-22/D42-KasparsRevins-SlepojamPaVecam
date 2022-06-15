using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SPVWeb.Data;
using SPVWeb.Models;

namespace SPVWeb.Controllers
{
    [Authorize]
    public class ReservationsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext _db;
        public ReservationsController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            this.userManager = userManager;
        }
        public IActionResult Create(int mountainId)
        {
            var model = new Reservation
            {
                MountainId = mountainId,
                ReservationDay = DateTime.Now,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);
                reservation.UserId = user.Id;
                _db.Reservations.Add(reservation);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Mountain", new { area = "" });
            }
            return View(reservation);

        }
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            IQueryable<Reservation> reservations = _db.Reservations.Where(R=>R.UserId == user.Id);
            return View(reservations);
        }
    }
}
