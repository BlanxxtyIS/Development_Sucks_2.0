using FluentValidation;

namespace DevelopmentSucks.Application.DTO.Users;

public class UserDtoValidator: AbstractValidator<UserDto>
{
    public UserDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Username)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(20);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(30)
            .Matches("[A-Z]").WithMessage("Пароль должен содержать заглавную букву")
            .Matches("[a-z]").WithMessage("Пароль должен содержать строчную букву")
            .Matches("[0-9]").WithMessage("Пароль должен содержать цифру");
    }
}
