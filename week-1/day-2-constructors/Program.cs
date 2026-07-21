using System.Diagnostics.Contracts;

Console.WriteLine("\nUSER CONSTRUCTOR\n");

Console.Write("Input Full Name: ");
string fullName = Console.ReadLine();
Console.Write("Input Department: ");
string department = Console.ReadLine();
Console.Write("Input Role: ");
string role = Console.ReadLine();


//Called out a class and added arguments for the parameters of the constructor
User user1 = new User(fullName, department, role);
Console.WriteLine("");
Console.WriteLine($"Name: {user1.FullName}");
Console.WriteLine($"Department: {user1.Department}");
Console.WriteLine($"Role: {user1.Role}");

Console.WriteLine("\nTICKET + CONSTRUCTOR + PRIORITY\n");

Console.Write("Input Subject: ");
string sub = Console.ReadLine();
Console.Write("Input Description: ");
string desc = Console.ReadLine();
Console.Write("Input status: ");
string stat = Console.ReadLine();
Console.Write("Input Severity: ");
int sev = Convert.ToInt32(Console.ReadLine());

Ticket ticket = new Ticket(sub, desc,  stat, sev);
Console.WriteLine("");
Console.WriteLine($"Subject: {ticket.Subject}");
Console.WriteLine($"Description: {ticket.Description}");
Console.WriteLine($"Status: {ticket.Status}");
//Utilized method in a class
Console.WriteLine($"Severity: {ticket.GetPriorityLabel()}");

class Ticket
{
    public string Subject { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public int Severity { get; set; }
    //Created a constructor in a class with parameters assigned
    public Ticket(string subject, string description, string status, int severity)
    {
        Subject = subject;
        Description = description;
        Status = status;
        Severity = severity;
    }
    //Created a method in a class
    public string GetPriorityLabel()
    {
        if (Severity == 1)
        {
            return "1 - High";
        }
        else if (Severity == 2)
        {
            return "2 - Medium";
        }
        else if (Severity == 3)
        {
            return "3 - Low";
        }
        else
        {
            return "Unidentified";
        }
    }
}
class User
{
    public string FullName { get; set; }
    public string Department { get; set; }
    public string Role { get; set; }

    public User(string fullName, string department, string role)
    {
        FullName = fullName;
        Department = department;
        Role = role;
    }
}
