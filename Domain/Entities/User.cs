using System.ComponentModel.DataAnnotations;

namespace DemoApi.Domain.Entities
{
    public class User
    { 
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
