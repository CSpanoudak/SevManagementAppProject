using SevManagementApp.DAO;
using SevManagementApp.DTO;
using SevManagementApp.Models;

namespace SevManagementApp.Service
{
    public interface IEnrollmentService
    {
        List<Enrollment> GetAllEnrollments();
        void InsertEnrollment(EnrollmentDTO? dto);
        void UpdateEnrollment(EnrollmentDTO?  dto);
        Enrollment? DeleteEnrollment(EnrollmentDTO?  dto);
        Enrollment? GetEnrollment(int id);
    }
}
