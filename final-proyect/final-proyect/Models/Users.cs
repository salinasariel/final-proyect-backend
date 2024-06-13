using final_proyect.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace final_proyect_backend.Models
{
    
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public UsersRoleEnum Rol { get; set; }
        public bool UserState { get; set; }
        public string ProfilePhoto {  get; set; }


    }
}
