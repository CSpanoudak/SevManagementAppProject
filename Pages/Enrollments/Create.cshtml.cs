using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevManagementApp.DAO;
using SevManagementApp.DTO;
using SevManagementApp.Models;
using SevManagementApp.Service;
using SevManagementApp.Validator;

namespace SevManagementApp.Pages.Enrollments
{
    public class CreateModel : PageModel
    {
        private readonly IEnrollmentDAO enrollmentDAO = new EnrollmentDAOImpl();
        private readonly IEnrollmentService service;


        public CreateModel()
        {
            service = new EnrollmentServiceImpl(enrollmentDAO);
        }

        internal EnrollmentDTO enrollmentDto = new();
        internal string errorMessage = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            enrollmentDto.CourseId = int.Parse(Request.Form["courseid"]);
            enrollmentDto.StudentId = int.Parse(Request.Form["studentid"]);

            errorMessage = EnrollmentValidator.Validate(enrollmentDto);

            if (!errorMessage.Equals("")) return;

            try
            {
                service.InsertEnrollment(enrollmentDto);
                Response.Redirect("/Enrollments/Index");

            } catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }
    }
}
