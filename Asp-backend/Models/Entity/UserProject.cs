namespace AspBackend.Models.Entity;

public class UserProject
{
    public int AccountId { get; set; }
    public Account Account { get; set; }

    public int ProjectId { get; set; } 
    public Project Project { get; set; } 
}
