using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSportsApp.Data
{
    public class Sport
    {
        // One sport can have many teams
        // There can be many sports for a school
        [Key]
        public int SportId { get; set; }

        public Guid OwnerId { get; set; }

        [Required]
        [Display(Name ="Sport")]
        public string SportName { get; set; }
        [Required, MaxLength(200, ErrorMessage ="There are too many characters in this field.")]
        [Display(Name = "Sport Description")]
        public string SportDescription { get; set; }

        public ICollection<Team> ListOfTeams { get; set; }

        public Sport()
        {
            ListOfTeams = new HashSet<Team>();
            ListOfSchools = new HashSet<School>();
        }

        public ICollection<School> ListOfSchools { get; set; }

    }
}
