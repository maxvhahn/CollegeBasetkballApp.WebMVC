using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSportsApp.Models.ConferenceModels
{
    public class ConferenceListItem
    {
        public int? ConferenceId { get; set; }
        [Display(Name = "Conference Name")]
        public string ConferenceName { get; set; }
        //public IEnumerable<Conference> Conferences 
        //{
        //    get { return Conferences.OrderBy(cN => cN.Conferences); }
        //}
    }
}
