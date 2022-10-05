using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HipDronesProject.Data.Models
{
    public abstract class MediaFile
    {
        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        public int Id { get; set; }

        public string? Source { get; set; }
        

        public string? Description { get; set; }

        [Required]
        public int Cost { get; set; }

        public long Size { get; set; }

        public string? Location { get; set; }

        public string? Path { get; set; }

    }
}
