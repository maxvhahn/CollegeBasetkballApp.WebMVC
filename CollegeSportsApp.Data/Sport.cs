using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSportsApp.Data
{
    public class Sport
    {
        [Key]
        public int SportId { get; set; }
        [Required]
        public string SportName { get; set; }
        public List<Team> ListOfTeams { get; set; }
    }
}
