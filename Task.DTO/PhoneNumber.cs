namespace Task.DTO;

public class PhoneNumber
{
    public int Id { get; set; }
    public Person Person { get; set; } = null!;
    public PhoneType PhoneType { get; set; }
    public string Number { get; set; } = null!;
    public DateTime CreateDate { get; set; }
    public bool IsActive { get; set; }
}
public enum PhoneType : byte
{
    Mobile = 0,
    Office = 1,
    Home = 2
}
