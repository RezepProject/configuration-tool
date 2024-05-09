using System.ComponentModel.DataAnnotations;
using FluentValidation;


namespace ConfigurationTool.Model;

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; } = String.Empty;

    public List<Answer> Answers { get; set; } = new();
}

public class CreateQuestion
{
    public string Text { get; set; } = String.Empty;
    public List<CreateAnswer> Answers { get; set; } = new();
}

public class AnswerListValidator : AbstractValidator<List<CreateAnswer>>
{
    public AnswerListValidator()
    {
        RuleForEach(a => a)
            .SetValidator(new CreateAnswerValidator());
    }
}

public class CreateQuestionValidator : ValidatorBase<CreateQuestion>
{
    public CreateQuestionValidator()
    {
        RuleFor(q => q.Text)
            .MinimumLength(10)
            .WithMessage("min length 10")
            .NotNull()
            .NotEmpty();
        RuleFor(q => q.Answers)
            .NotNull()
            .SetValidator(new AnswerListValidator())
            .NotEmpty();
    }
}