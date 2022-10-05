using System;
using System.Collections.Generic;

namespace HipDronesProject.Data.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PilotId { get; set; }
        public Pilot? Pilot { get; set; }
        public List<Picture>? Picture { get; set; }
        public List<Video>? Video { get; set; }
        public List<Measurement>? Measurement { get; set; }
        public bool Paid { get; set; }
    }
}
