using SevManagementApp.DTO;
using SevManagementApp.Models;

namespace SevManagementApp.Service
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        void InsertStudent(StudentDTO? dto);
        void UpdateStudent(StudentDTO? dto);
        Student? DeleteStudent(StudentDTO? dto);
        Student? GetStudent(int id);
    }
}
