using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSportsApp.Models.SchoolModels
{
    public class SchoolEdit
    {
        public int SchoolId { get; set; }
        [Display(Name = "School Name")]
        public string SchoolName { get; set; }
        [Display(Name = "Mascot Name")]
        public string MascotName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
