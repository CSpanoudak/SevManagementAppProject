using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevManagementApp.DAO;
using SevManagementApp.DTO;
using SevManagementApp.Models;
using SevManagementApp.Service;
using SevManagementApp.Validator;

namespace SevManagementApp.Pages.Teachers
{
    public class UpdateModel : PageModel
    {
        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();
        private readonly ITeacherService service;

        public UpdateModel()
        {
            service = new TeacherServiceImpl(teacherDAO);
        }

        internal TeacherDTO teacherDto = new();
        internal string errorMsg = "";
        public void OnGet()
        {
            try
            {
                Teacher? teacher;

                int id = int.Parse(Request.Query["id"]);
                teacher = service.GetTeacher(id);
                if (teacher != null)
                {
                    teacherDto = ConvertToDto(teacher);
                }
            }
            catch (Exception e)
            {
                errorMsg = e.Message;
                return;
            }
        }

        public void OnPost()
        {
            errorMsg = "";
            teacherDto.Id = int.Parse(Request.Form["id"]);
            teacherDto.Firstname = Request.Form["Firstname".Trim()];
            teacherDto.Lastname = Request.Form["Lastname".Trim()];

            errorMsg = TeacherValidator.Validate(teacherDto);
            if (!errorMsg.Equals("")) return;

            try 
            {
                service.UpdateTeacher(teacherDto);
                Response.Redirect("/Teachers/Index");
            }
            catch(Exception e) 
            {
                errorMsg = e.Message;
                return;
            
            }
           
        }

        private TeacherDTO ConvertToDto(Teacher teacher)
        {
            return new TeacherDTO()
            {
                Id = teacher.Id,
                Firstname = teacher.Firstname,
                Lastname = teacher.Lastname
            };
        }
    }
}
