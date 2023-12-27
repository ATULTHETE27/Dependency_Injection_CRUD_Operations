using Asp.netCoreMVCIntro.Models;
using Asp.netCoreMVCIntro.Service;
using Asp.netCoreMVCIntro.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp.netCoreMVCIntro.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Student> students = await _studentService.GetAllStudent();
            return View(students);
        }

        public async Task<IActionResult> DisplayStudentsByCollageId(int id)
        {
            IEnumerable<Student> students = await _studentService.GetStudentsByCollageId(id);
            return View(students);
        }

        public async Task<IActionResult> GetStudentsByStudentId(int id)
        {
            Student student = await _studentService.GetStudentById(id);
            return View(student);

        }

        [HttpGet]
        public async Task<IActionResult> AddNewStudent()
        {
            var students = await _studentService.GetAllStudent();
            ViewBag.Students = new SelectList(students, "Id", "First_Name","Last_Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewStudent(StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                var students = await _studentService.GetAllStudent();
                ViewBag.Students = new SelectList(students, "CollageId", "First_Name");
                return View(student);
            }

            _studentService.AddStudent(student);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> EditStudent(int id)
        {
            Student student = await _studentService.GetStudentById(id);
            var data = new StudentViewModel()
            {
                First_Name = student.First_Name,
                Last_Name = student.Last_Name,
                Percentage = student.Percentage,
                DOB = student.DOB
            };
            var students = await _studentService.GetAllStudent();
            ViewBag.Students = new SelectList(students, "Id", "First_Name");
            return View(data);
        }


        [HttpPost]
        public async Task<IActionResult> EditStudent(StudentViewModel modifiedData)
        {

            if (!ModelState.IsValid)
            {
                return View(modifiedData);
            }
            Student student = await _studentService.GetStudentById(modifiedData.Id);
            student.First_Name = modifiedData.First_Name;
            student.Last_Name = modifiedData.Last_Name;
            student.Percentage = modifiedData.Percentage;
            student.DOB = modifiedData.DOB;
            _studentService.UpdateStudent(student);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteStudent(int id)
        {
            _studentService.DeleteStudent(id);
            return RedirectToAction("Index");
        }

       
    }
}
