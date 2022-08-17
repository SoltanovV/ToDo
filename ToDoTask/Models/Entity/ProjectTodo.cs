using System.Text.Json.Serialization;
using ToDoTaskServer.Models.Entity;

namespace ASPbackend.Models.Entity;
public class ProjectTodo
{

    public int ProjectId { get; set; }

    [JsonIgnore]
    public Project Project { get; set; }

    public int TodoId { get; set; }

    [JsonIgnore]
    public Todo Todo { get; set; }
}
