using Dofus.Hdv.Api.Models.CreatePrice;
using Dofus.Hdv.Core.Features.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dofus.Hdv.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PriceController : ControllerBase
{
    private readonly ILogger<PriceController> logger;
    private readonly IMediator mediator;

    public PriceController(ILogger<PriceController> logger, IMediator mediator)
    {
        this.logger = logger;
        this.mediator = mediator;
    }

    /// <summary>
    ///     Crée un prix pour un item dofus.
    /// </summary>
    /// <param name="request"> les informations nécessaire a la création d'un prix.</param>
    /// <returns> ok. </returns>
    /// <response code="204"> </response>
    [HttpPost(Name = "CreatePrice")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> CreateDigimon(CreatePriceRequest request)
    {
        logger.LogInformation("A request to create a digimon started");

        await mediator.Send(new CreatePriceCommand(
            request.DofusId,
            request.ServerId,
            request.Value,
            request.CreatedAt,
            request.CreatedBy));

        return Ok();
    }
}