using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSportsApp.Models.TeamModels
{
    public class TeamDetail
    {
        public int? TeamId { get; set; }
        [Display(Name = "Team Name")]
        public string TeamName { get; set; }
    }
}
