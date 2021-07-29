using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSportsApp.Models.ConferenceModels
{
    public class ConferenceDetail
    {
        public int ConferenceId { get; set; }
        [Display(Name = "Conference Name")]
        public string ConferenceName { get; set; }
    }
}
