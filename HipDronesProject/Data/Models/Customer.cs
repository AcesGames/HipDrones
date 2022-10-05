using System.ComponentModel.DataAnnotations;
namespace HipDronesProject.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First FileName is reqired")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last FileName is reqired")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

     }
}
