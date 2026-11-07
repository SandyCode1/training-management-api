
using Microsoft.AspNetCore.Mvc;

namespace TrainingManagement.API.Controllers;

[ApiController]
[Route("api/version")]
public class VersionController : ControllerBase
{
    [HttpGet]
    public IActionResult GetVersion()
    {
        return Ok(new
        {
            Application = "Training Management API",
            Version = "1.0.0",
            Environment = "Azure App Service",
            Deployment = "GitHub Actions"
        });
    }
}
