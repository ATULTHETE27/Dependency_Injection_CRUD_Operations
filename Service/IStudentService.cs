using Asp.netCoreMVCIntro.Models;
using Asp.netCoreMVCIntro.ViewModels;

namespace Asp.netCoreMVCIntro.Service
{
    public interface IStudentService
    {
        void AddStudent(StudentViewModel student);

        Student UpdateStudent(Student student);

        void DeleteStudent(int Id);

        Task<Student> GetStudentById(int Id);

        Task<IEnumerable<Student>> GetAllStudent();

        Task<IEnumerable<Collage>> GetAllCollages();

        Task<IEnumerable<Student>> GetStudentsByCollageId(int collageId);
    }
}
