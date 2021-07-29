using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSportsApp.Data
{
    public class School
    {
        // One school can have many teams (many sports teams)
        // An individual school can be part of many conferences 
        [Key]
        public int SchoolId { get; set; }
        public Guid OwnerId { get; set; }

        [Required]
        [Display(Name ="Name of School")]
        public string SchoolName { get; set; }

        [Required]
        [Display(Name ="Mascot")]
        public string MascotName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        public string Address
        {
            get
            {
                return (City + " " + State);
            }
        }

        [ForeignKey(nameof(Conference))]
        public int ConferenceId { get; set; }
        public virtual Conference Conference { get; set; }
        
        [ForeignKey(nameof(Sport))]
        public int? SportId { get; set; }
        public virtual Sport Sport { get; set; }
    }
}
