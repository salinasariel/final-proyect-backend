using final_proyect.Models.Auth;
using final_proyect.Models.DTO;

namespace final_proyect.Interfaces
{
    public interface IAuthServices
    {
        public LoginResult Login(CredentialsDTO credentials);

    }
}
