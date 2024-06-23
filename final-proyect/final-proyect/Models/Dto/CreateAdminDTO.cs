using System.ComponentModel.DataAnnotations;

namespace final_proyect.Models.Dto
{
    public class CreateAdminDTO
    {
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UsersRoleEnum Rol { get; set; } = UsersRoleEnum.Admin;
        public bool UserState { get; set; } = true;
        public string ProfilePhoto { get; set; }
        public string About { get; set; }
        public string WorkArea { get; set; }
    }
}
