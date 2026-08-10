// Represents the data and behavior of a support ticket.
public class Ticket
{
    public string Subject { get; set;}
    public string Description { get; set;}
    public string Status { get; set;}
    public int Severity { get; set;}
    public int Month { get; set; }
    public int Day { get; set; }
    public int Year { get; set; }
    public string Brand { get; set;}
    public int Age { get; set;}
    public bool IsDamaged { get; set;}
    public string AffectedUser { get; set; }


    public Ticket(string subject, string description, string status, int severity, int month, int day, int year, string brand, int age, bool isDamaged, string  affectedUser)
    {
        Subject = subject;
        Description = description;
        Status = status;
        Severity = severity;
        Month = month;
        Day = day;
        Year = year;
        Brand = brand;
        Age = age;
        IsDamaged = isDamaged;
        AffectedUser = affectedUser;

    }
}