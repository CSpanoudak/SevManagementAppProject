using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevManagementApp.DAO;
using SevManagementApp.DTO;
using SevManagementApp.Models;
using SevManagementApp.Service;
using SevManagementApp.Validator;

namespace SevManagementApp.Pages.Students
{
    public class UpdateModel : PageModel
    {

        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService service;


        public UpdateModel()
        {
            service = new StudentServiceImpl(studentDAO);
        }

        internal StudentDTO studentDto = new();
        internal string errorMessage = "";
        
        
        public void OnGet()
        {
            try
            {
                Student? student;

                int id = int.Parse(Request.Query["id"]);
                student = service.GetStudent(id);
                
                if (student != null)
                {
                    studentDto = ConvertToDto(student);
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
            studentDto.Id = int.Parse(Request.Form["id"]);
            studentDto.Firstname = Request.Form["firstname"];
            studentDto.Lastname = Request.Form["lastname"];

            // validate
            errorMessage = StudentValidator.Validate(studentDto);

            if (!errorMessage.Equals("")) return;

            try
            {
                service.UpdateStudent(studentDto);
                Response.Redirect("/Students/Index");
            } catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }


        private StudentDTO ConvertToDto(Student student)
        {
            return new StudentDTO()
            {
                Id = student.Id,
                Firstname = student.Firstname,
                Lastname = student.Lastname
            };
        }
    }
}
