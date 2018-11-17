namespace SportChallenge.Core.Models
{
    public class Game : IIDentifiable
    {
        public int Id { get; set; }
        public Team HomeTeam { get; set; }
        public Team GuestTeam { get; set; }
        public int? HomeTeamResult { get; set; }
        public int? GuestTeamResult { get; set; }
    }
}
