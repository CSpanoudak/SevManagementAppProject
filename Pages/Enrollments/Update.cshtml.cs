using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevManagementApp.DAO;
using SevManagementApp.DTO;
using SevManagementApp.Models;
using SevManagementApp.Service;
using SevManagementApp.Validator;

namespace SevManagementApp.Pages.Enrollments
{
    public class UpdateModel : PageModel
    {

        private readonly IEnrollmentDAO enrollmentDAO = new EnrollmentDAOImpl();
        private readonly IEnrollmentService service;


        public UpdateModel()
        {
            service = new EnrollmentServiceImpl(enrollmentDAO);
        }

        internal EnrollmentDTO enrollmentDto = new();
        internal string errorMessage = "";
        
        
        public void OnGet()
        {
            try
            {
                Enrollment? enrollment;

                int id = int.Parse(Request.Query["id"]);
                enrollment = service.GetEnrollment(id);
                
                if (enrollment != null)
                {
                    enrollmentDto = ConvertToDto(enrollment);
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
            enrollmentDto.Id = int.Parse(Request.Form["id"]);
            enrollmentDto.CourseId = int.Parse(Request.Form["courseid"]);
            enrollmentDto.StudentId = int.Parse(Request.Form["studentid"]);

            errorMessage = EnrollmentValidator.Validate(enrollmentDto);


            if (!errorMessage.Equals("")) return;

            try
            {
                service.UpdateEnrollment(enrollmentDto);
                Response.Redirect("/Enrollments/Index");
            } catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }


        private EnrollmentDTO ConvertToDto(Enrollment enrollment)
        {
            return new EnrollmentDTO()
            {
                Id = enrollment.Id,
                CourseId = enrollment.CourseId,
                StudentId = enrollment.StudentId
            };
        }
    }
}
