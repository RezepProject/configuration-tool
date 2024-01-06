namespace ConfigurationTool.Model;

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; }

    public List<Answer>? Answers { get; set; }
    public bool IsEditing { get; set; } = false;
}

public class CreateQuestion
{
    public string Text { get; set; }
    public List<CreateAnswer>? Answers { get; set; }
}