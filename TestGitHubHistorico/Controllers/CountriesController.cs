using Microsoft.AspNetCore.Mvc;

namespace TestGitHubHistorico.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
        var countries = new[]
        {
            "Colombia",
            "Mexico",
            "Argentina",
            "Chile",
            "Peru",
            "Ecuador",
            "Spain",
            "Canada"
        };

        return Ok(countries);
    }
}