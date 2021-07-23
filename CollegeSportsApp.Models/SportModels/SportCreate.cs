using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSportsApp.Models.SportModels
{
    public class SportCreate
    {
        [Required]
        public string SportName { get; set; }

        [Required]
        public string SportDescription { get; set; }

        public int ConferenceId { get; set; }
    }
}
