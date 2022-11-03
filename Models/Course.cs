using System.ComponentModel.DataAnnotations.Schema;

namespace SevManagementApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public int TeachersId { get; set; }
    }
}
