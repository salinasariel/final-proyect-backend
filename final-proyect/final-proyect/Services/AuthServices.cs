using final_proyect.Data;
using final_proyect.HashData;
using final_proyect.Interfaces;
using final_proyect.Models.Auth;
using final_proyect.Models.DTO;
using final_proyect_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace final_proyect.Services
{

    public class AuthServices : IAuthServices
    {
        private readonly IHashData _hashData;
        private readonly IUserService _userService;

        public AuthServices(IHashData hashData, IUserService userService)
        {
            _hashData = hashData;
            _userService = userService;
        }

        public LoginResult Login(CredentialsDTO credentials)
        {
            var user = _userService.GetUserByEmail(credentials.Mail);
            if (user == null) 
            {
                return new LoginResult { Success = false, Message = "Email incorrecto" };
            }

            var passwordValidation = _hashData.Verify(user.PasswordHash, credentials.Password);
            if (!passwordValidation)
            {
                return new LoginResult { Success = false , Message = "Contraseña incorrecta"};
            }

            return new LoginResult { Message ="Ok", Success = true };
        }
    }
}
