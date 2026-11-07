using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingManagement.API.Models;

namespace TrainingManagement.API.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetCourses()
        {
            var courses = new List<Course>
        {
            new()
            {
                Id = 1,
                Title = "AZ-900 Azure Fundamentals",
                DurationHours = 8
            },
            new()
            {
                Id = 2,
                Title = "ASP.NET Core Web API",
                DurationHours = 24
            }
        };

            return Ok(courses);
        }
    }
}