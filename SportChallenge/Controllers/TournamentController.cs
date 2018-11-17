using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SportChallenge.MediatorRequests;
using SportChallenge.Models;

namespace SportChallenge.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
    public class TournamentController : ControllerBase
    {
		private readonly IMediator _mediator;

        public TournamentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("add")]
        public async Task<IActionResult> CreateTournament(TournamentCreateModel model)
        {
            var request = new CreateTournamentRequest(model.TournamentName, model.TeamNames);
            await _mediator.Send(request);

            return Ok();
        }
    }
}
