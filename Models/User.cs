namespace UsersManager.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Company Company { get; set; }
}
