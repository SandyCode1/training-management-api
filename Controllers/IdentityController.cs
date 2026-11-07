
using Microsoft.AspNetCore.Mvc;

namespace TrainingManagement.API.Controllers;

[ApiController]
[Route("api/identity")]
public class IdentityController : ControllerBase
{
    [HttpGet]
    public IActionResult GetIdentity()
    {
        // This lab endpoint is intended only for
        // an App Service protected by Easy Auth.
        var principalId =
            Request.Headers["X-MS-CLIENT-PRINCIPAL-ID"];

        var principalName =
            Request.Headers["X-MS-CLIENT-PRINCIPAL-NAME"];

        var identityProvider =
            Request.Headers["X-MS-CLIENT-PRINCIPAL-IDP"];

        return Ok(new
        {
            AuthHeaderPresent =
                !string.IsNullOrEmpty(principalId.ToString()),

            NameHeaderPresent =
                !string.IsNullOrEmpty(principalName.ToString()),

            IdentityProvider =
                identityProvider.ToString()
        });
    }
}
