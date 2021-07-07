using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSportsApp.Data
{
    public class Team
    {
        [Required]
        public string TeamName { get; set; }
        public List<Athlete> ListOfAthletes { get; set; }
    }
}
