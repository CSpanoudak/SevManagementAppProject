using SevManagementApp.Models;

namespace SevManagementApp.DAO
{
    public interface ITeacherDAO
    {
        /// <summary>
        /// Insert a Teacher into the database
        /// </summary>
        /// <param name="teacher">Teacher's first and last name</param>
        void Insert(Teacher? teacher);

        /// <summary>
        /// Update a teacher's info ,who is already registered in the database
        /// </summary>
        /// <param name="teacher">Teacher's first and last name</param>
        void Update(Teacher? teacher); 

        /// <summary>
        /// Delete a teacher from the databse
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns>Deleted teacher</returns>
        Teacher? Delete(Teacher? teacher);
        
        /// <summary>
        /// Searching a teacher
        /// </summary>
        /// <param name="id">Teacher's id</param>
        /// <returns>Teacher whose id matches the input id</returns>
        Teacher? GetTeacher(int id);
       
        /// <summary>
        /// List of teachers
        /// </summary>
        /// <returns>A list of all inserted teachers</returns>
        List<Teacher> GetAll();
    }
}
