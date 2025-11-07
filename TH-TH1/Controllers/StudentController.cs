using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;
using TH_TH1.Models;

namespace TH_TH1.Controllers
{
    public class StudentController : Controller
    {
        private List<Student> listStudents = new List<Student>();

        public StudentController()
        {
            listStudents = new List<Student>()
            {
                new Student() { Id = 101, Name = "Hai Nam", Branch = Branch.IT, Gender = Gender.Male, 
                    IsRegular = true, Address = "A1-2018", Email = "nam@g.com" },
                new Student() { Id = 102, Name = "Hai Nam", Branch = Branch.EE, Gender = Gender.Male,
                    IsRegular = true, Address = "A1-2019", Email = "nam@g.com" },
                new Student() { Id = 103, Name = "Minh Tu", Branch = Branch.BE, Gender = Gender.Female,
                    IsRegular = true, Address = "A1-2020", Email = "nam@g.com" },
                new Student() { Id = 104, Name = "Hai Nam", Branch = Branch.CE, Gender = Gender.Male,
                    IsRegular = true, Address = "A1-2021", Email = "nam@g.com" },
                new Student() { Id = 105, Name = "Hai Nam", Branch = Branch.IT, Gender = Gender.Female,
                    IsRegular = true, Address = "A1-2014", Email = "nam@g.com" }
            };
        }

        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1" },
                new SelectListItem { Text = "BE", Value = "2" },
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" },
            };

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student s, IFormFile Avatar)
        {
            s.Id = listStudents.Last<Student>().Id + 1;

            if (Avatar != null && Avatar.Length > 0)
            {
                var fileName = Path.GetFileName(Avatar.FileName);
                var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                if (!Directory.Exists(uploadsPath))
                    Directory.CreateDirectory(uploadsPath);

                var filePath = Path.Combine(uploadsPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Avatar.CopyToAsync(stream);
                }

                s.Avatar = "/images/" + fileName;
            }
            listStudents.Add(s);

            return RedirectToAction("Index", listStudents);
        }
    }
}
