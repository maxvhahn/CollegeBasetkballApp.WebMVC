using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSportsApp.Models.SchoolModels
{
    public class SchoolListItem
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string MascotName { get; set; }
        public string Address
        {
            get
            {
                return (City + " " + State);
            }
        }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
    }
}
