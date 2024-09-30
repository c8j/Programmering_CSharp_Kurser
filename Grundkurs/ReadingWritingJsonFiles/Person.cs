namespace ReadingWritingJsonFiles;

public class Person
{
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";
    public int Age { get; set; }

    public override string ToString() =>
    $"Name: {FirstName} {LastName}, Age: {Age}, Phone: {Phone}, " +
    $"Email: {Email}, Date created: {CreatedAt:g}";
}
