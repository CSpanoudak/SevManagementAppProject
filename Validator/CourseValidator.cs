using SevManagementApp.DTO;

namespace SevManagementApp.Validator
{
    public class CourseValidator
    {
        public CourseValidator() {}

        public static string Validate(CourseDTO? dto)
        {
            if (dto!.CourseName!.Length == 0) 
            {
                return "Course name should not be empty";
            }
            if (dto!.Description!.Length == 0)
            {
                return "Course description should not be empty";
            }
            if (dto!.TeachersId == 0)
            {
                return "Please insert a teacher";
            }
            return "";
        }
    }
}
