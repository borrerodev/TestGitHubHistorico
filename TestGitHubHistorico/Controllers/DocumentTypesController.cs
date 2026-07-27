using Microsoft.AspNetCore.Mvc;

namespace TestGitHubHistorico.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentTypesController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<DocumentType>> Get()
    {
        var documentTypes = new[]
        {
            new DocumentType { Id = 1, Code = "CC", Name = "Cédula de Ciudadanía", Country = "Colombia" },
            new DocumentType { Id = 2, Code = "TI", Name = "Tarjeta de Identidad", Country = "Colombia" },
            new DocumentType { Id = 3, Code = "NIT", Name = "Número de Identificación Tributaria", Country = "Colombia" },
            new DocumentType { Id = 4, Code = "CE", Name = "Cédula de Extranjería", Country = "Colombia" },
            new DocumentType { Id = 5, Code = "PAS", Name = "Pasaporte", Country = "Colombia" },
            new DocumentType { Id = 6, Code = "DNI", Name = "Documento Nacional de Identidad", Country = "Argentina" },
            new DocumentType { Id = 7, Code = "RUT", Name = "Rol Único Tributario", Country = "Chile" },
            new DocumentType { Id = 8, Code = "RFC", Name = "Registro Federal de Contribuyentes", Country = "Mexico" }
        };

        return Ok(documentTypes);
    }
}

public class DocumentType
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
}