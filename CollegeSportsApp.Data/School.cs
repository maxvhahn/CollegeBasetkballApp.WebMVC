using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSportsApp.Data
{
    public class School
    {
        [Key]
        public int SchoolId { get; set; }
        [Required]
        public string SchoolName { get; set; }
        [Required]
        public string MyProperty { get; set; }
        [Required]
        public string MascotName { get; set; }
        public List<Sport> ListOfSports { get; set; }
    }
}
