using SevManagementApp.DAO;
using SevManagementApp.DTO;
using SevManagementApp.Models;

namespace SevManagementApp.Service
{
    public class EnrollmentServiceImpl : IEnrollmentService
    {
        private readonly IEnrollmentDAO dao;

        public EnrollmentServiceImpl(IEnrollmentDAO dao)
        {
            this.dao = dao;
        }
        public Enrollment? DeleteEnrollment(EnrollmentDTO? dto)
        {
            if (dto is null) return null;

            try
            {
                Enrollment? enrollment = Convert(dto);
                return dao.Delete(enrollment);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<Enrollment> GetAllEnrollments()
        {
            try
            {
                return dao.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Enrollment>();
            }
        }

        public Enrollment? GetEnrollment(int id)
        {
            try
            {
                return dao.GetEnrollment(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void InsertEnrollment(EnrollmentDTO? dto)
        {
            if (dto is null) return;

            try
            {
                Enrollment? enrollment = Convert(dto);
                dao.Insert(enrollment);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void UpdateEnrollment(EnrollmentDTO? dto)
        {
            if (dto is null) return;

            try
            {
                Enrollment? enrollment = Convert(dto);
                dao.Update(enrollment);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        private Enrollment? Convert(EnrollmentDTO dto)
        {
            if (dto == null) return null;

            return new Enrollment()
            {
                Id = dto.Id,
                StudentId = dto.StudentId,
                CourseId = dto.CourseId,

            };
        }
    }
}
