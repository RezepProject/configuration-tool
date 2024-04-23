namespace ConfigurationTool.Model;

public class Assistant
{
    public string Name { get; set; }
    public string BackgroundImageUrl { get; set; }
    public string Language { get; set; }
    public double TalkingSpeed { get; set; } = 1;
    public string GreetingMessage { get; set; }
    public bool IsExpanded { get; set; } = true;
}