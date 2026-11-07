using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace TrainingManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConfigurationController(
       IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                ApplicationName =
                    _configuration["TrainingSettings:ApplicationName"],

                MaxStudents =
                    _configuration.GetValue<int>(
                        "TrainingSettings:MaxStudents")
            });
        }
    }
}
