using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSportsApp.Models.SchoolModels
{
    public class SchoolCreate
    {
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
    }
}
