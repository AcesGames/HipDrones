using System.ComponentModel.DataAnnotations;

namespace HipDronesProject.Data.Models
{
    public class Video : MediaFile
    {
        [Required] public string? Length { get; set; }


    }
}
