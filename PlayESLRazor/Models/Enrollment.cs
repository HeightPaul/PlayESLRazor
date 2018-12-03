namespace PlayESLRazor.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int TournamentId { get; set; }
        public int CompTeamId { get; set; }

        public Tournament Tournament { get; set; }
        public CompTeam CompTeam { get; set; }
    }
}
