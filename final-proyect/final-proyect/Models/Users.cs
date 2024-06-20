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
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UsersRoleEnum Rol { get; set; }
        public bool UserState { get; set; }
        public string ProfilePhoto {  get; set; }
        public string About { get; set; } 



    }
}
