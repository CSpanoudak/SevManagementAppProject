using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevManagementApp.DAO;
using SevManagementApp.DTO;
using SevManagementApp.Models;
using SevManagementApp.Service;
using SevManagementApp.Validator;

namespace SevManagementApp.Pages.Courses
{
    public class UpdateModel : PageModel
    {

        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService service;


        public UpdateModel()
        {
            service = new CourseServiceImpl(courseDAO);
        }

        internal CourseDTO courseDto = new();
        internal string errorMessage = "";
        
        
        public void OnGet()
        {
            try
            {
                Course? course;

                int id = int.Parse(Request.Query["id"]);
                course = service.GetCourse(id);
                
                if (course != null)
                {
                    courseDto = ConvertToDto(course);
                }
            } catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }    
        }

        public void OnPost()
        {
            errorMessage = "";
            // Get DTO
            courseDto.Id = int.Parse(Request.Form["id"]);
            courseDto.CourseName = Request.Form["coursename"];
            courseDto.Description = Request.Form["description"];
            courseDto.TeachersId = int.Parse(Request.Form["teacherid"]);


            // validate
            errorMessage = CourseValidator.Validate(courseDto);

            if (!errorMessage.Equals("")) return;

            try
            {
                service.UpdateCourse(courseDto);
                Response.Redirect("/Courses/Index");
            } catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }


        private CourseDTO ConvertToDto(Course course)
        {
            return new CourseDTO()
            {
                Id = course.Id,
                CourseName = course.CourseName,
                Description = course.Description,
                TeachersId = course.TeachersId
            };
        }
    }
}
