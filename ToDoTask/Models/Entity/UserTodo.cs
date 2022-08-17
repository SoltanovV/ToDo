namespace AspBackend.Models.Entity;

public class UserTodo
{
    public int UserId { get; set; }
    public User User { get; set; }

    public int TodoId { get; set; }
    public Todo Todo { get; set; }
}
