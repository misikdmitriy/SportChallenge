using SportChallenge.Core.Models;

namespace SportChallenge.Core.Extensions
{
    public static class GameExtension
    {
        public static bool IsGamePlayed(this Game game)
        {
            return game.Result != null;
        }
    }
}
