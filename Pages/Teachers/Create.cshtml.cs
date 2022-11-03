using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevManagementApp.DAO;
using SevManagementApp.DTO;
using SevManagementApp.Models;
using SevManagementApp.Service;
using SevManagementApp.Validator;

namespace SevManagementApp.Pages.Teachers
{
    public class CreateModel : PageModel
    {
        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();
        private readonly ITeacherService service;

        public CreateModel()
        {
            service = new TeacherServiceImpl(teacherDAO);
        }

        internal TeacherDTO teacherDto = new();
        internal string errorMsg = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            teacherDto.Firstname = Request.Form["firstname".Trim()];
            teacherDto.Lastname = Request.Form["lastname".Trim()];

            errorMsg = TeacherValidator.Validate(teacherDto);

            if (!errorMsg.Equals("")) return;

            try 
            {
                service.InsertTeacher(teacherDto);
                Response.Redirect("/Teachers/Index");
            
            }
            catch (Exception e) 
            { 
                errorMsg = e.Message;
                return;
            }
        }
    }
}
