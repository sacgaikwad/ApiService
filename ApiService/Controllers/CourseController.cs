using ApiService.Models;
using ApiService.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseRepository _courseRepository;
        private ILogger<CourseController> _logger;
        public CourseController(ICourseRepository courseRepository, ILogger<CourseController> logger)
        {
            _courseRepository = courseRepository;
            _logger = logger;
        }


        [HttpGet]
        public IEnumerable<Course> Get()
        {
            _logger.LogInformation("Entering get courses");
            var response = _courseRepository.GetCourses();
            _logger.LogInformation("Exiting get courses");
            return response.ToList();
        }
    }
}
