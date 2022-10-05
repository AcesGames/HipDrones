namespace HipDronesProject.Data.Models
{
    public class Drone
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? RegId { get; set; }
        public string? Info { get; set; }
        public string? Category { get; set; }
        public bool Available { get; set; }

    }
}
