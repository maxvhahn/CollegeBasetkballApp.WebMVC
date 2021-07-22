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
        [Key]
        public int TeamId { get; set; }

        [Required]
        [Display(Name ="Team")]
        public string TeamName { get; set; }

        [ForeignKey(nameof(Sport))]
        public int? SportId { get; set; }
        public virtual Sport Sport { get; set; }
        public ICollection<Athlete> ListOfAthletes { get; set; }
        public Team()
        {
            ListOfAthletes = new HashSet<Athlete>();
        }
    }
}
