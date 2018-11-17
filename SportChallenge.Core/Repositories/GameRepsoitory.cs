using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportChallenge.Core.DbContexts;
using SportChallenge.Core.Models;
using SportChallenge.Core.Repositories.Contracts;

namespace SportChallenge.Core.Repositories
{
    public class GameRepsoitory : DbRepository<Game>, IGameRepository
    {
        public GameRepsoitory(SportContext context) : base(context)
        {
        }

        protected override IQueryable<Game> GetQuery(SportContext context)
        {
            return context.Games
                .Include(x => x.HomeTeam)
                .ThenInclude(x => x.Tournament)
                .Include(x => x.GuestTeam)
                .ThenInclude(x => x.Tournament)
                .Include(x => x.Result)
                .Include(x => x.Round);
        }

        public async Task<Game[]> GetTournamentGames(int tournamentId)
        {
            return await GetQuery(Context)
                .Where(x => x.HomeTeam.Tournament.Id == tournamentId)
                .ToArrayAsync();
        }
    }
}
