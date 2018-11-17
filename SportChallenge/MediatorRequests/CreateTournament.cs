using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SportChallenge.Core.Models;
using SportChallenge.Core.Services.Contracts;

namespace SportChallenge.MediatorRequests
{
    public class CreateTournamentRequest : IRequest<Tournament>
    {
        public string TournamentName { get; }
        public string[] TeamNames { get; }

        public CreateTournamentRequest(string tournamentName, string[] teamNames)
        {
            TeamNames = teamNames;
            TournamentName = tournamentName;
        }
    }

    public class CreateTournamentHandler : IRequestHandler<CreateTournamentRequest, Tournament>
    {
        private readonly ITournamentFactory _tournamentFactory;

        public CreateTournamentHandler(ITournamentFactory tournamentFactory)
        {
            _tournamentFactory = tournamentFactory;
        }

        public Task<Tournament> Handle(CreateTournamentRequest request, CancellationToken cancellationToken)
        {
            return _tournamentFactory.Create(request.TournamentName, request.TeamNames);
        }
    }
}
