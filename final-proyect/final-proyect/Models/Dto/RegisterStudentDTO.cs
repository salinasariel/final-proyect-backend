using System.ComponentModel.DataAnnotations;

namespace final_proyect.Models.Dto
{
    public class RegisterStudentDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int FileNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Dni {  get; set; }

        // --------------------------------------------------
        public UsersRoleEnum Rol {  get; set; } = UsersRoleEnum.Student;

        public bool UserState {  get; set; } = false;







    }
}
