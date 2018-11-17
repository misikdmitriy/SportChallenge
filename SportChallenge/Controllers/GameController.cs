using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SportChallenge.MediatorRequests;
using SportChallenge.Models;

namespace SportChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
		private readonly IMediator _mediator;

        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("{tournamentName}")]
        public async Task<IActionResult> SaveResult(string tournamentName, SaveResultModel saveResultModel)
        {
            var request = new CreateGameResultRequest(tournamentName, 
                saveResultModel.GuestTeamName, saveResultModel.GuestTeamResult, 
                saveResultModel.HomeTeamName, saveResultModel.HomeTeamResult);

            await _mediator.Send(request);

            return Ok();
        }
    }
}
