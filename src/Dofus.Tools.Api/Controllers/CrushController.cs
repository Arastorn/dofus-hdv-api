using Dofus.Tools.Api.Models.Crushes.CreateCrush;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dofus.Tools.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CrushController : ControllerBase
{
    private readonly ILogger<CrushController> logger;
    private readonly IMediator mediator;

    public CrushController(ILogger<CrushController> logger, IMediator mediator)
    {
        this.logger = logger;
        this.mediator = mediator;
    }

    /// <summary>
    ///     Crée un brisage pour un item dofus.
    /// </summary>
    /// <param name="request"> les informations nécessaire a la création d'un brisage.</param>
    /// <returns> ok. </returns>
    /// <response code="204"> </response>
    [HttpPost(Name = "CreatePrice")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> CreatePrice(CreateCrushRequest request)
    {
        logger.LogInformation("A request to create a price started");

        await Task.CompletedTask;

        return Ok();
    }
}