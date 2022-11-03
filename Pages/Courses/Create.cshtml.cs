using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevManagementApp.DAO;
using SevManagementApp.DTO;
using SevManagementApp.Models;
using SevManagementApp.Service;
using SevManagementApp.Validator;

namespace SevManagementApp.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService service;


        public CreateModel()
        {
            service = new CourseServiceImpl(courseDAO);
        }

        internal CourseDTO courseDto = new();
        internal string errorMessage = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            courseDto.CourseName = Request.Form["coursename"];
            courseDto.Description = Request.Form["description"];
            courseDto.TeachersId = int.Parse(Request.Form["teacherid"]);



            errorMessage = CourseValidator.Validate(courseDto);

            if (!errorMessage.Equals("")) return;

            try
            {
                service.InsertCourse(courseDto);
                Response.Redirect("/Courses/Index");

            } catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }
    }
}
