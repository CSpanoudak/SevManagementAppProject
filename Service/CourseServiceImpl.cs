using SevManagementApp.DAO;
using SevManagementApp.DTO;
using SevManagementApp.Models;

namespace SevManagementApp.Service
{
    public class CourseServiceImpl : ICourseService
    {
        private readonly ICourseDAO dao;

        public CourseServiceImpl(ICourseDAO dao) 
        {
            this.dao = dao;
        }
        public Course? DeleteCourse(CourseDTO? dto)
        {
            if (dto is null) return null;

            try
            {
                Course? course = Convert(dto);
                return dao.Delete(course);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<Course> GetAllCourses()
        {
            try
            {
                return dao.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Course>();
            }
        }

        public Course? GetCourse(int id)
        {
            try
            {
                return dao.GetCourse(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void InsertCourse(CourseDTO? dto)
        {
            if (dto is null) return;

            try
            {
                Course? course = Convert(dto);
                dao.Insert(course);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void UpdateCourse(CourseDTO? dto)
        {
            if (dto is null) return;

            try
            {
                Course? course = Convert(dto);
                dao.Update(course);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private Course? Convert(CourseDTO dto)
        {
            if (dto == null) return null;

            return new Course()
            {
                Id = dto.Id,
                CourseName = dto.CourseName,
                Description = dto.Description,
                TeachersId = dto.TeachersId
                
            };
        }
    }
}
