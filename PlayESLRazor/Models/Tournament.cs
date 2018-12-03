using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayESLRazor.Models
{
    public enum Tier
    {
        Minor, Major, Premier
    }
    public class Tournament
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TournamentId { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(5)]
        public string PlayerFormat { get; set; }
        public Tier? Tier { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
