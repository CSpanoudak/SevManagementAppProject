using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevManagementApp.DAO;
using SevManagementApp.Models;
using SevManagementApp.Service;

namespace SevManagementApp.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService service;


        internal List<Course> courses = new();

        public IndexModel()
        {
            service = new CourseServiceImpl(courseDAO);
        }
 
        public IActionResult OnGet()
        {
            
            courses = service!.GetAllCourses();
            return Page();
        }
    }
}
