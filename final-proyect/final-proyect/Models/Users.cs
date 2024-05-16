using final_proyect.Models;
using System.ComponentModel.DataAnnotations;

namespace final_proyect_backend.Models
{
    
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UsersRoleEnum Rol { get; set; }
        public bool UserState { get; set; }


    }
}
