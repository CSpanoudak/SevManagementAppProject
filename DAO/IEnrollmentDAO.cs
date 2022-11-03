using SevManagementApp.Models;

namespace SevManagementApp.DAO
{
    public interface IEnrollmentDAO
    {
        Enrollment? GetEnrollment(int id);
        void Insert(Enrollment? enrollment);
        void Update(Enrollment? enrollment);
        Enrollment? Delete(Enrollment? enrollment);

        List<Enrollment> GetAll();
    }
}
