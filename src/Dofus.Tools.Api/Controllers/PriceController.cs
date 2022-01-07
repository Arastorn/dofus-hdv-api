using Dofus.Tools.Api.Models.Prices.CreatePrice;
using Dofus.Tools.Api.Models.Prices.GetPricesByIds;
using Dofus.Tools.Core.Features.Commands.CreatePrice;
using Dofus.Tools.Core.Features.Queries.GetPricesByIds;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dofus.Tools.Api.Controllers;

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
    public async Task<IActionResult> CreatePrice(CreatePriceRequest request)
    {
        logger.LogInformation("A request to create a price started");

        await mediator.Send(new CreatePriceCommand(
            request.DofusId,
            request.ServerId,
            request.Value,
            request.CreatedBy));

        return Ok();
    }

    /// <summary>
    ///    récupère tout les prix associé a un id dofus
    /// </summary>
    /// <param name="dofusId"> Id de l'item dofus dont on veut récupérer le prix</param>
    /// <param name="serverId"> Le serveur associé dont on veut récupérer les prix</param>
    /// <returns> ok. </returns>
    /// <response code="200"> Tout les prix étant associé a l'item en question</response>
    [HttpGet(Name = "GetPrices")]
    [ProducesResponseType(typeof(GetPricesByIdsResponse[]), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPrices([FromQuery] int dofusId, [FromQuery] short serverId)
    {
        logger.LogInformation("A request to get prices started");
        var prices = await mediator.Send(new GetPricesByIdsQuery(dofusId, serverId));

        return Ok(prices.Select(p => (GetPricesByIdsResponse)p));
    }
}