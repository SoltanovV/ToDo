namespace AspBackend.Models.Entity;

public class ProjectTodo
{
    public int ProjectId { get; set; }
    public Project Project { get; set; }

    public int TodoId { get; set; }
    public Todo Todo { get; set; }
}
