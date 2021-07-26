using ApiService.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Service
{
    public class CourseRepository : ICourseRepository
    {
        private ILogger<CourseRepository> _logger;

        public CourseRepository(ILogger<CourseRepository> logger)
        {
            _logger = logger;
        }
        public List<Course> GetCourses()
        {
            _logger.LogInformation("Entering GetCourses");

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "azuretutorialdemo.database.windows.net";
            builder.UserID = "azuredemo";
            builder.Password = "sachin123!@#";
            builder.InitialCatalog = "azuretutorial";

            List<Course> courses = new List<Course>();

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                String sql = "SELECT CourseId,CourseName,Rating FROM [dbo].[Course]";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Course course = new Course();
                            course.CourseId = reader["CourseId"].ToString();
                            course.CourseName = reader["CourseName"].ToString();
                            course.Rating = reader["Rating"].ToString();
                            courses.Add(course);
                        }
                    }
                }
            }
            _logger.LogInformation("Exiting GetCourses");
            return courses;
        }
    }
}
