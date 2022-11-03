using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevManagementApp.DAO;
using SevManagementApp.DTO;
using SevManagementApp.Models;
using SevManagementApp.Service;

namespace SevManagementApp.Pages.Teachers
{
    public class DeleteModel : PageModel { 
    private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();
    private readonly ITeacherService service;

    internal string errorMsg = "";

    public DeleteModel()
    {
        service = new TeacherServiceImpl(teacherDAO);
    }

    public void OnGet()
    {
        TeacherDTO teacherDTO = new();

        try
        {
            Teacher? teacher;

            int id = int.Parse(Request.Query["id"]);

            teacherDTO.Id = id;
            teacher = service.DeleteTeacher(teacherDTO);
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
