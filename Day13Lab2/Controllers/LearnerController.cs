using Day13Lab_231230949_14_11_2025_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day13Lab_231230949_14_11_2025_2.Controllers
{
    public class LearnerController : Controller
    {
        private AspnetLab4Context db;
        public LearnerController(AspnetLab4Context context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var learners = db.Learners.Include(m => m.Major).ToList();
            return View(learners);
        }
    }
}
