using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevManagementApp.DAO;
using SevManagementApp.Models;
using SevManagementApp.Service;

namespace SevManagementApp.Pages.Enrollments
{
    public class IndexModel : PageModel
    {
        private readonly IEnrollmentDAO enrollmentDAO = new EnrollmentDAOImpl();
        private readonly IEnrollmentService service;


        internal List<Enrollment> enrollments = new();

        public IndexModel()
        {
            service = new EnrollmentServiceImpl(enrollmentDAO);
        }
 
        public IActionResult OnGet()
        {
            
            enrollments = service!.GetAllEnrollments();
            return Page();
        }
    }
}
