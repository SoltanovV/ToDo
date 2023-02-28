namespace AspBackend.Models.Entity;

public class UserTodo
{
    public int AccountId { get; set; }
    public Account Account { get; set; }

    public int TodoId { get; set; }
    public Todo Todo { get; set; }
}
