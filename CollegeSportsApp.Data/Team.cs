using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSportsApp.Data
{
    public class Team
    {
        [Required]
        [Display(Name ="Team")]
        public string TeamName { get; set; }

        [ForeignKey(nameof(School))]
        public int SchoolId { get; set; }
        public virtual School School { get; set; }
        public ICollection<Athlete> ListOfAthletes { get; set; }
        public Team()
        {
            ListOfAthletes = new HashSet<Athlete>();
        }
    }
}
