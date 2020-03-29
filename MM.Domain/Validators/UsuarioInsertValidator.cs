using FluentValidation;

namespace MM.Domain.Validators
{
    public class UsuarioInsertValidator : AbstractValidator<Usuario>
    {
        public UsuarioInsertValidator()
        {
            RuleFor(x => x.Nome).NotNull().WithMessage("É necessário um nome válido.");
            RuleFor(x => x.Email).EmailAddress().NotNull().WithMessage("É necessário um e-mail válido.");
            RuleFor(x => x.Senha).NotNull().MinimumLength(6).WithMessage("É necessário uma senha válida com pelo menos 6 caracteres.");
        }
    }
}
