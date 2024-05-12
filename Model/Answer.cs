using FluentValidation;

namespace ConfigurationTool.Model;

public class Answer
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public string? User { get; set; }
    public int QuestionId { get; set; }
    public Question? Question { get; set; }
}

public class UpdateAnswer
{
    public string? Text { get; set; }
    public string? User { get; set; }
    public int? QuestionId { get; set; }
}

public class CreateAnswer
{
    public string? Text { get; set; }

    public string? User { get; set; }
    
    public CreateAnswer()
    {
    }
    
    public CreateAnswer(Answer answer)
    {
        Text = answer.Text;
        User = answer.User;
    }
}

public class CreateAnswerValidator : ValidatorBase<CreateAnswer>
{
    public CreateAnswerValidator()
    {
        RuleFor(a => a.Text)
            .MinimumLength(10)
            .WithMessage("min length 10")
            .NotNull()
            .NotEmpty();
    }
}

public class AnswerValidator : AbstractValidator<Answer>
{
    public AnswerValidator()
    {
        RuleFor(a => a.Text)
            .MinimumLength(10)
            .WithMessage("min length 10")
            .NotNull()
            .NotEmpty();
        RuleFor(a => a.User)
            .MinimumLength(10)
            .WithMessage("min length 10")
            .NotNull()
            .NotEmpty();
    }
}