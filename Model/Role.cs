using backend.Entities;

namespace ConfigurationTool.Model;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<ConfigUser>? Users { get; set; }
}