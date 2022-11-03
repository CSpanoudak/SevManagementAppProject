using SevManagementApp.DTO;
using SevManagementApp.Models;

namespace SevManagementApp.Service
{
    public interface ITeacherService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Teacher> GetAllTeachers();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        void InsertTeacher(TeacherDTO? dto);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        void UpdateTeacher(TeacherDTO? dto);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Teacher? DeleteTeacher(TeacherDTO? dto);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Teacher? GetTeacher(int id);
    }
}
