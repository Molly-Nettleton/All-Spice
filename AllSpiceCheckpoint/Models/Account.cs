namespace AllSpiceCheckpoint.Models;

public class Profile : IRepoItem<string>
{
    public string Name { get; set; }
    public string Picture { get; set; }
    public string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class Account : Profile
{
    public string Email { get; set; }
}


