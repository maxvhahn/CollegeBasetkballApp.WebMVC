using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSportsApp.Models.SportModels
{
    public class SportEdit
    {
        public int SportId { get; set; }
        [Display(Name ="Sport Name")]
        public string SportName { get; set; }
        [Display(Name ="Sport Description")]
        public string SportDescription { get; set; }
    }
}
