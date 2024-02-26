namespace ConfigurationTool.Model;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int RoleId { get; set; }
}

public class CreateUser
{
    public string Email { get; set; }
    public int RoleId { get; set; }
}

public class Invitation
{
    public int Id { get; set; }
    public Guid Token { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public int RoleId { get; set; }
}

public class NewUser
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }
}