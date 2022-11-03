using SevManagementApp.DAO.DBUtil;
using SevManagementApp.Models;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace SevManagementApp.DAO
{
    public class EnrollmentDAOImpl : IEnrollmentDAO
    {
        public Enrollment? Delete(Enrollment? enrollment)
        {
            if (enrollment == null) return null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn != null) conn.Open(); else return null;

                string sql = "DELETE FROM ENROLLMENTS WHERE ID = @id";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@id", enrollment.Id);

                int rowsAffected = command.ExecuteNonQuery();
                return (rowsAffected > 0) ? enrollment : null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public List<Enrollment> GetAll()
        {
            List<Enrollment> enrollments = new List<Enrollment>();
            
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn != null) conn.Open(); else return null;

                string sql = "SELECT * FROM ENROLLMENTS";

                using SqlCommand command = new SqlCommand(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    Enrollment enrollment = new Enrollment()
                    {
                        Id = reader.GetInt32(0),
                        CourseId = reader.GetInt32(1),
                        StudentId = reader.GetInt32(2),
                    };
                    enrollments.Add(enrollment);
                }

                return enrollments;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public Enrollment? GetEnrollment(int id)
        {
            Enrollment? enrollment = null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open();

                string sql = "SELECT * FROM ENROLLMENTS WHERE ID = @id";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@id", id);

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    enrollment = new Enrollment()
                    {
                        Id = reader.GetInt32(0),
                        CourseId= reader.GetInt32(1),
                        StudentId= reader.GetInt32(2),


                    };
                }

                return enrollment;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Insert(Enrollment? enrollment)
        {
            if (enrollment == null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open(); else return;

                string sql = "INSERT INTO ENROLLMENTS " +
                    "(COURSE_ID, STUDENT_ID) VALUES " +
                    "(@courseid, @studentid)";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@id", enrollment.Id);
                command.Parameters.AddWithValue("@courseid", enrollment.CourseId);
                command.Parameters.AddWithValue("@studentid", enrollment.StudentId);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Update(Enrollment? enrollment)
        {
            if (enrollment == null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null) conn.Open(); else return;

                string sql = "UPDATE ENROLLMENTS SET COURSE_ID = @courseid, " +
                             "STUDENT_ID = @studentid WHERE ID = @id";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@id", enrollment.Id);
                command.Parameters.AddWithValue("@courseid", enrollment.CourseId);
                command.Parameters.AddWithValue("@studentid", enrollment.StudentId);
               

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }
    }
}
