using SevManagementApp.DTO;

namespace SevManagementApp.Validator
{
    /// <summary>
    /// Checks validity of DTO
    /// </summary>
    public class TeacherValidator
    {
        private TeacherValidator() { }

        public static string Validate(TeacherDTO? dto)
        {
                if ((dto!.Firstname!.Length < 4) || (dto!.Firstname!.Length < 4))
                {
                    return "Firstname or Lastname should not be less than 3 characters";
                }
                else 
                {
                    return "";
                }
        }
    }
}
