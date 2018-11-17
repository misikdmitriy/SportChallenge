using SportChallenge.Core.Models;
using SportChallenge.Core.Services.Contracts;

namespace SportChallenge.Core.Services
{
    public class GameFactory : IGameFactory
    {
        public Game CreateGame(Team home, Team guest)
        {
            return new Game
            {
                GuestTeam = guest,
                HomeTeam = home,
                Result = null
            };
        }
    }
}
