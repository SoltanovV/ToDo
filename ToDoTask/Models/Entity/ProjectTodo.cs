using System.Text.Json.Serialization;

namespace AspBackend.Models.Entity;
public class ProjectTodo
{

    public int ProjectId { get; set; }

    [JsonIgnore]
    public Project Project { get; set; }

    public int TodoId { get; set; }

    [JsonIgnore]
    public Todo Todo { get; set; }
}
