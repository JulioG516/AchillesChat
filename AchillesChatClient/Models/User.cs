namespace AchillesChatClient.Models;

public class User
{
    public string Id { get; set; }

    public string Name { get; set; }

    public bool IsLoggedIn { get; set; } = false;

    public bool IsOverSeer { get; set; }
}