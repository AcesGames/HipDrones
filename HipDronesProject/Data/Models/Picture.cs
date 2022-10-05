using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HipDronesProject.Data.Models
{
    public class Picture : MediaFile
    {   
        public int Height { get; set; } 
        public int Width { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? Altitude { get; set; }
    }
}
