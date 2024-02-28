namespace Task.DTO;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreateDate { get; set; }
    public bool IsActive { get; set; }
    public ICollection<Person>? People { get; set; }
}
