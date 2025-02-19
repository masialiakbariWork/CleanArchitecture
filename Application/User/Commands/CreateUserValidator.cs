using FluentValidation;

namespace Application.User.Commands;

public class CreateUserValidator: AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Family)
            .NotNull()
            .NotEmpty();

        //RuleFor(x => x.Email)
        //    .NotNull()
        //    .NotEmpty;

        RuleFor(x => x.Email)
            .NotNull()
            .NotEmpty();
    }
}
