namespace Task.DTO;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public Gender Gender { get; set; }
    public string PersonalNumber { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public City City { get; set; } = null!;
    public ICollection<PhoneNumber> PhoneNumbers { get; set; } = null!;
    /* Photo  */
    public DateTime CreateDate { get; set; }
    public bool IsActive { get; set; }


    public ICollection<Relationship> Relationships1 { get; set; } = null!;
    public ICollection<Relationship> Relationships2 { get; set; } = null!;

}
public enum Gender : byte
{
    Male = 0,
    Female = 1
}
