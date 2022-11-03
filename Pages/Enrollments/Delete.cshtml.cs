using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevManagementApp.DAO;
using SevManagementApp.DTO;
using SevManagementApp.Models;
using SevManagementApp.Service;

namespace SevManagementApp.Pages.Enrollments
{
    public class DeleteModel : PageModel
    {
        private readonly IEnrollmentDAO enrollDAO = new EnrollmentDAOImpl();
        private readonly IEnrollmentService service;


        internal string errorMessage = "";

        public DeleteModel()
        {
            service = new EnrollmentServiceImpl(enrollDAO);
        }

        public void OnGet()
        {
            EnrollmentDTO enrollDTO = new();

            try
            {
                Enrollment? enroll;

                int id = int.Parse(Request.Query["id"]);

                enrollDTO.Id = id;
                enroll = service.DeleteEnrollment(enrollDTO);
                Response.Redirect("/Enrollments/Index");

            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }
    }
}
