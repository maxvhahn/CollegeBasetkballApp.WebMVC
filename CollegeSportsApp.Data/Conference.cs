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
        // One Conference can have many Schools
        [Key]
        public int ConferenceId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        [Display(Name ="Conference")]
        public string ConferenceName { get; set; }
        public ICollection<School> ListOfSchools { get; set; }
        public Conference()
        {
            ListOfSchools = new HashSet<School>();
        }
        
    }
}
