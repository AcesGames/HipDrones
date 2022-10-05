using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HipDronesProject.Models
{
    public class AssignmentViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string PilotId { get; set; }

        public List<SelectListItem> Pilots { get; set; } = new List<SelectListItem>();
    

        public string Type { get; set; }
        public bool Paid { get; set; }
       }
}
