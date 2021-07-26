using ApiService.Models;
using Microsoft.Extensions.Configuration;
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
        private IConfiguration _configuration;

        public CourseRepository(ILogger<CourseRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public List<Course> GetCourses()
        {
            _logger.LogInformation("Entering GetCourses");

            List<Course> courses = new List<Course>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
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
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            _logger.LogInformation("Exiting GetCourses");
            return courses;
        }
    }
}
