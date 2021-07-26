using ApiService.Models;
using System.Collections.Generic;

namespace ApiService.Service
{
    public interface ICourseRepository
    {
        public List<Course> GetCourses();
    }
}
