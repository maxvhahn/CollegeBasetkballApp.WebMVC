using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSportsApp.Data
{
    public class Conference
    {
        [Key]
        public int ConferenceId { get; set; }
        public ICollection<School> ListOfSchools { get; set; }
        [Required]
        public string ConferenceName { get; set; }
        [ForeignKey(nameof(School))]
        public int SchoolId { get; set; }
        public virtual School School { get; set; }
    }
}
