using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevManagementApp.DAO;
using SevManagementApp.DTO;
using SevManagementApp.Models;
using SevManagementApp.Service;

namespace SevManagementApp.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService service;

        internal string errorMessage = "";

        public DeleteModel()
        {
            service = new StudentServiceImpl(studentDAO);
        }

        public void OnGet()
        {
            StudentDTO studentDTO = new();

            try
            {
                Student? student;

                int id = int.Parse(Request.Query["id"]);

                studentDTO.Id = id;
                student = service.DeleteStudent(studentDTO);
                Response.Redirect("/Students/Index");
                
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }
    }
}
