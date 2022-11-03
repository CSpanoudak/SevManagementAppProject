using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevManagementApp.DAO;
using SevManagementApp.DTO;
using SevManagementApp.Models;
using SevManagementApp.Service;
using SevManagementApp.Validator;

namespace SevManagementApp.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService service;


        public CreateModel()
        {
            service = new StudentServiceImpl(studentDAO);
        }

        internal StudentDTO studentDto = new();
        internal string errorMessage = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            studentDto.Firstname = Request.Form["firstname"];
            studentDto.Lastname = Request.Form["lastname"];

            errorMessage = StudentValidator.Validate(studentDto);

            if (!errorMessage.Equals("")) return;

            try
            {
                service.InsertStudent(studentDto);
                Response.Redirect("/Students/Index");

            } catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }
    }
}
