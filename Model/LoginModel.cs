using FluentValidation;

namespace ConfigurationTool.Model;

public class LoginModel
{
    public string UserIdentification { get; set; } = "";
    public string Password { get; set; } = "";
}

class LoginModelValidator : ValidatorBase<LoginModel>
{
    public LoginModelValidator()
    {
        RuleFor(x => x.UserIdentification)
            .NotEmpty()
            .WithMessage("Email is required");
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required");
    }
}