namespace Martix.Domain.Entities;

public class StoryEntity
{
    public string Title { get; set; }

    public string Content { get; set; }

    public List<string> Tags { get; set; } = new List<string>();
}