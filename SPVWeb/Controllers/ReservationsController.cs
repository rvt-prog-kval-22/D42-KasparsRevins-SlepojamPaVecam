using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPVWeb.Data;
using SPVWeb.Models;
using SPVWeb.ViewModel;

namespace SPVWeb.Controllers
{
    
    public class ReservationsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext _db;
        public ReservationsController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            this.userManager = userManager;
        }
        [AllowAnonymous]
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
        [AllowAnonymous]
        public async Task<IActionResult> Create(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _db.Reservations.Add(reservation);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Mountain", new { area = "" });
            }
            return View(reservation);

        }
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            var reservations = await _db.Reservations.Where(R=>R.ReservationDay >= DateTime.Today).ToListAsync();
            var mountains = _db.Mountains.Where(mountain => reservations.Any(reservation => reservation.MountainId == mountain.Id));
            List<ReservationsViewModel> ViewModel = new List<ReservationsViewModel>();
            foreach (var reservation in reservations)
            {
                var mountain = _db.Mountains.Where(m => m.Id == reservation.MountainId).FirstOrDefault();
                if (mountain != null)
                {
                    var totalcost = reservation.Brauceji * mountain.SkiLiftRent;
                    if (reservation.NeedHelmetRent)
                    {
                        totalcost += reservation.Brauceji * mountain.HelmetRent; 
                    }
                    if (reservation.NeedSkiiRent)
                    {
                        totalcost += reservation.Brauceji * mountain.SkiiRent;
                    }
                    ViewModel.Add(new ReservationsViewModel
                    {
                        Name = mountain.Name,
                        Brauceji = reservation.Brauceji,
                        ReservationDay = reservation.ReservationDay,
                        TotalCost = totalcost,

                    });
                }
            }
            return View(ViewModel);
        }
    }
}
