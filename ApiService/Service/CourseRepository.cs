using ApiService.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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

           

            List<Course> courses = new List<Course>();
            courses.Add(new Course { CourseId = "1", CourseName = "AZ-204 Developing Azure solutions", Rating = "4.5" });
            courses.Add(new Course { CourseId = "2", CourseName = "AZ-303 Architecting Azure solutions", Rating = "4.6" });
            courses.Add(new Course { CourseId = "3", CourseName = "DP-203 Azure Data Engineer", Rating = "4.7" });
            _logger.LogInformation("Exiting GetCourses");
            return courses;
        }
    }
}
