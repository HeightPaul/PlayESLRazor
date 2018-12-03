using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayESLRazor.Models
{
    public class CompTeam
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompTeamId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Team name cannot be longer than 50 characters.")]
        [Display(Name = "Team Name")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        public ICollection<AppUser> AppUsers { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
