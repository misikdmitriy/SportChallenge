using System.Threading.Tasks;
using SportChallenge.Core.Models;

namespace SportChallenge.Core.Services.Contracts
{
    public interface ITournamentFactory
    {
        Task<Tournament> Create(string name, params string[] teamNames);
    }
}
