using System.ComponentModel.DataAnnotations;

namespace final_proyect.Models.Dto
{
    public class RegisterEnterpriseDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public long Cuit { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }

        public UsersRoleEnum Rol { get; set; } = UsersRoleEnum.Enterprise;

        public bool UserState { get; set; } = false;
    }
}
