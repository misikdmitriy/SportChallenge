using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http.Internal;
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

        [HttpPut("")]
        public async Task<IActionResult> CreateTournament(TournamentCreateModel model)
        {
            var request = new CreateTournamentRequest(model.TournamentName, model.TeamsCount);
            var tournament = await _mediator.Send(request);

            return Ok(tournament.Name);
        }

        [HttpGet("all")]
        [HttpGet("")]
        public Task<IActionResult> GetTournament(string tournamentName)
        {
            return GetTournament(tournamentName, GameType.All);
        }

        [HttpGet("played")]
        public Task<IActionResult> GetPlayedTournament(string tournamentName)
        {
            return GetTournament(tournamentName, GameType.Played);
        }

        [HttpGet("planned")]
        public Task<IActionResult> GetPlanedTournament(string tournamentName)
        {
            return GetTournament(tournamentName, GameType.Planned);
        }

        [HttpGet("table")]
        public async Task<IActionResult> GetTournamentTable(string tournamentName)
        {
            var request = new GetTournamentTableRequest(tournamentName);
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("csv")]
        public async Task<IActionResult> ToCsv(string tournamentName)
        {
            var request = new ToScvRequest(tournamentName);
            var result = await _mediator.Send(request);

            return File(result, System.Net.Mime.MediaTypeNames.Application.Octet,
                $"{tournamentName}.csv");
        }

        [HttpPut("csv")]
        public async Task<IActionResult> FromCsv(string tournamentName)
        {
            Request.EnableRewind();

            var request = new FromScvRequest(Request.Form.Files.First(), tournamentName);
            await _mediator.Send(request);

            return Ok();
        }

        private async Task<IActionResult> GetTournament(string tournamentName, GameType gameType)
        {
            var request = new GetTournamentRequest(tournamentName, gameType);
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
