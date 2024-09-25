namespace ScheduleDomain.Entities;

public class Entity
{
    public Guid Id { get; set; } = new Guid();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DeletedAt { get; set; }
}