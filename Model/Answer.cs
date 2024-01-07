namespace ConfigurationTool.Model;

public class Answer
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string User { get; set; }
    public bool IsEditing { get; set; } = false;
}

public class CreateAnswer
{
    public string Text { get; set; }
    public string User { get; set; }
}

public class UpdateAnswer
{
    public string Text { get; set; }
    public string User { get; set; }
}