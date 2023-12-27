using Asp.netCoreMVCIntro.Context;
using Asp.netCoreMVCIntro.Models;
using Asp.netCoreMVCIntro.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Asp.netCoreMVCIntro.Service
{
    public class StudentService : IStudentService
    {
        private readonly CollageDbContext _context;
        public StudentService(CollageDbContext context)
        {
            _context = context;
        }

        public void AddStudent(StudentViewModel student)
        {
            var newStudent = new Student()
            {
                First_Name = student.First_Name,
                Last_Name = student.Last_Name,
                Percentage = student.Percentage,
                DOB = student.DOB,
                CollageId = student.CollageId
            };
            _context.Students.AddAsync(newStudent);
            _context.SaveChangesAsync();
        }

        public void DeleteStudent(int Id)
        {
            Student student = _context.Students.Find(Id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Student>> GetAllStudent()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<IEnumerable<Collage>> GetAllCollages()
        {
            return await _context.Collages.ToListAsync();
        }

        public async Task<Student> GetStudentById(int Id)
        {
            return await _context.Students.FindAsync(Id);
        }

        public async Task<IEnumerable<Student>> GetStudentsByCollageId(int studentId)
        {
            return await _context.Students.Where(a => a.CollageId == studentId).ToListAsync();
        }

        public Student UpdateStudent(Student updatedStudent)
        {
            _context.Update(updatedStudent);
            _context.SaveChanges();
            return updatedStudent;
        }
    }
}