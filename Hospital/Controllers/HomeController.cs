using System.Diagnostics;
using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Appointment()
        {
            var doctors = _context.Doctors.ToList();
            return View(doctors);
        }

        public IActionResult CompleteAppointment(int id )
        {
            var doctors = _context.Doctors.Find(id);
            return View(doctors);
        }

        public IActionResult CreateData( string name , DateTime dateTime, string time, string Name)
        {
            _context.Appointments.Add(new()
            {
               
                Patientname = name,
                AppointmentDate = dateTime,
             AppointmentTime = time
            });
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Modal()
        {
            
            return View();
        }


        public IActionResult ViewData()
        {
            var appointment = _context.Appointments.ToList();
            return View(appointment);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
