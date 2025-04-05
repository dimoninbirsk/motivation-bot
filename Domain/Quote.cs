namespace MotivationBot.Domain;

public record Quote
{
    public int Id { get; set; }
    public string Author { get; set; } = null!;
    public string Text { get; set; } = null!;
    public List<string> Tags { get; set; } = [];
}