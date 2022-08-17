using System.Text.Json.Serialization;

namespace AspBackend.Models.Entity;

public class UserProject
{
    [JsonIgnore]
    public int UserId { get; set; }

    public User User { get; set; }

    [JsonIgnore]
    public int ProjectId { get; set; }

    public Project Project { get; set; }
}
