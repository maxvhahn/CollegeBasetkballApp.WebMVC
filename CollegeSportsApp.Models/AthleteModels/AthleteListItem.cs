using CollegeSportsApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSportsApp.Models.AthleteModels
{
    public class AthleteListItem
    {
        public int AthleteId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName 
        {
            get
            {
                return (FirstName + " " + LastName);
            }
        }
        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }
        public virtual Team Team{ get; set; }
    }
}
