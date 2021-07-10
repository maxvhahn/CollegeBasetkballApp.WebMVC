using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeSportsApp.Models.SportModels
{
    public class SportCreate
    {
        public int SportId { get; set; }
        public string SportName { get; set; }
        public int SchoolId { get; set; }
    }
}
