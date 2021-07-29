using CollegeSportsApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSportsApp.Models.SchoolModels
{
    public class SchoolCreate
    {
        public int SchoolId { get; set; }
        [Required]
        [Display(Name ="School Name")]
        public string SchoolName { get; set; }
        [Required]
        [Display(Name = "Mascot Name")]
        public string MascotName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Display(Name ="Conference")]
        [ForeignKey(nameof(Conference))]
        public int ConferenceId { get; set; }
        public virtual Conference Conference { get; set; }
    }
}
