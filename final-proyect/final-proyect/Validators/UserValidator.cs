using final_proyect_backend.Models;
using FluentValidation;

namespace final_proyect.Validators
{
    public class UserValidator : AbstractValidator<Users>
    {
        public UserValidator() 
        {
            // Validaciones para el email
            RuleFor(x => x.Email)
                .NotNull().WithMessage("Email no puede ser nulo.")
                .NotEmpty().WithMessage("Email no puede estar vacío.")
                .EmailAddress().WithMessage("Email no tiene un formato válido.")
                .MaximumLength(50).WithMessage("Email puede tener un máximo de 50 caracteres.");

            // Validaciones para la contraseña
            RuleFor(x => x.PasswordHash)
                .NotNull().WithMessage("La contraseña no puede ser nula.")
                .NotEmpty().WithMessage("La contraseña no puede estar vacía.")
                .MinimumLength(8).WithMessage("La contraseña debe tener al menos 8 caracteres.")
                .MaximumLength(20).WithMessage("La contraseña puede tener un máximo de 20 caracteres.")
                .Matches("[A-Z]").WithMessage("La contraseña debe contener al menos una letra mayúscula.")
                .Matches("[a-z]").WithMessage("La contraseña debe contener al menos una letra minúscula.")
                .Matches("[0-9]").WithMessage("La contraseña debe contener al menos un número.")
                .Matches("[^a-zA-Z0-9]").WithMessage("La contraseña debe contener al menos un carácter especial.");
        }
    }
}
