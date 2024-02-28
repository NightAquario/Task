namespace Task.DTO;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public string PersonalNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public string Picture { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsDeleted { get; set; }

    public ICollection<Relationship> Relationships1 { get; set; }
    public ICollection<Relationship> Relationships2 { get; set; }

}
public enum Gender : byte
{
    Male = 0,
    Female = 1
}

public enum PhoneNumber : byte
{
    Mobile = 0,
    Office = 1,
    home = 2
}
