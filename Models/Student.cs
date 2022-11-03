namespace SevManagementApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }

        public ICollection<Enrollment>? Enrollments { get; set; }

    }
}
