using FluentValidation;

namespace MM.Domain.Validators
{
    public class UsuarioInsertValidator : AbstractValidator<Usuario>
    {
        public UsuarioInsertValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().MaximumLength(50).WithMessage("É necessário um nome válido.");
            RuleFor(x => x.Email).EmailAddress().MaximumLength(100).NotEmpty().WithMessage("É necessário um e-mail válido.");
            RuleFor(x => x.Senha).NotEmpty().MinimumLength(6).MaximumLength(50).WithMessage("É necessário uma senha válida com pelo menos 6 caracteres.");
        }
    }
}
