using SevManagementApp.DTO;

namespace SevManagementApp.Validator
{
    public class EnrollmentValidator
    {
        public EnrollmentValidator() { }

        public static string Validate(EnrollmentDTO? dto)
        {
            if (dto!.StudentId == 0)
            {
                return "Insert a student's id";
            }
            if (dto!.CourseId == 0)
            {
                return "Insert a course's id";
            }
            return "";
            
        }
    }
}
