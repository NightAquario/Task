namespace Task.DTO;

public class Relationship
{
    public int Id { get; set; }
    public int Person1Id { get; set; }
    public Person Person1 { get; set; } = null!;
    public int Person2Id { get; set; }
    public Person Person2 { get; set; } = null!;
    public RelationshipType RelationshipType { get; set; }
}
public enum RelationshipType : byte
{
    Colleague = 0,
    Acquaintance = 1,
    Relative = 2,
    Other = 3
}
