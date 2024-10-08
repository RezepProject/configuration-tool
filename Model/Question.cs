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
    
    public CreateQuestion()
    {
    }
    public CreateQuestion(Question question)
    {
        Text = question.Text;
        Answers = question.Answers.Select(a => new CreateAnswer(a)).ToList();
    }
}

public class CreateAnswerListValidator : AbstractValidator<List<CreateAnswer>>
{
    public CreateAnswerListValidator()
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
            .SetValidator(new CreateAnswerListValidator());
    }
}

public class AnswerListValidator : ValidatorBase<List<Answer>>
{
    public AnswerListValidator()
    {
        RuleForEach(a => a)
            .SetValidator(new AnswerValidator());
    }
}

public class QuestionValidator : ValidatorBase<Question>
{
    public QuestionValidator()
    {
        RuleFor(q => q.Text)
            .MinimumLength(10)
            .WithMessage("min length 10")
            .NotNull()
            .NotEmpty();
        RuleFor(q => q.Answers)
            .NotNull()
            .NotEmpty();
    }
}
