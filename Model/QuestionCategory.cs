namespace ConfigurationTool.Model;

public class QuestionCategory
{
    public int Id { get; set; }
    
    public string Name { get; set; }
}

public class CreateQuestionCategory
{
    public string Name { get; set; }
}