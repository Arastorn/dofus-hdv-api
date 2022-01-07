using Dofus.Tools.Api.Models.Crushes.CreateCrush;
using Dofus.Tools.Api.Models.Crushes.GetCrushesByIds;
using Dofus.Tools.Core.Features.Commands.CreateCrush;
using Dofus.Tools.Core.Features.Queries.GetCrushesByIds;
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
    [HttpPost(Name = "CreateCrush")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> CreateCrush(CreateCrushRequest request)
    {
        logger.LogInformation("A request to create a price started");

        await mediator.Send(new CreateCrushCommand(
            request.DofusId,
            request.ServerId,
            request.Value,
            request.CreatedBy));

        return Ok();
    }

    /// <summary>
    ///    récupère tout les brisage associé a un id dofus et son serveur
    /// </summary>
    /// <param name="dofusId"> Id de l'item dofus dont on veut récupérer le prix</param>
    /// <param name="serverId"> Le serveur associé dont on veut récupérer les prix</param>
    /// <returns> ok. </returns>
    /// <response code="200"> Tout les brisages étant associé a l'item en question et son serveur</response>
    [HttpGet(Name = "GetCrushes")]
    [ProducesResponseType(typeof(GetCrushesByIdsResponse[]), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCrushes([FromQuery] int dofusId, [FromQuery] short serverId)
    {
        logger.LogInformation("A request to get prices started");
        var crushes = await mediator.Send(new GetCrushesByIdsQuery(dofusId, serverId));

        return Ok(crushes.Select(p => (GetCrushesByIdsResponse)p));
    }
}