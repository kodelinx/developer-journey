static string GetPriorityLabel(int severity)
{
    if(severity == 1)
    {
        return "1 = High";
    }
    else if(severity == 2)
    {
        return "2 = Medium";
    }
    else if (severity == 3)
    {
        return "3 = Low";
    }
    else
    {
        return "Undefined";
    }
}

Console.WriteLine("USER CLASS\n");

User user1 = new User();

Console.Write("Fill in your full name: ");
user1.FullName = Console.ReadLine();

Console.Write("Indicate your department: ");
user1.Department = Console.ReadLine();

Console.Write("What is your role: ");
user1.Role = Console.ReadLine();

Console.Write("Input your Phone Number: ");
user1.Phone = Convert.ToInt64(Console.ReadLine());

Console.WriteLine($"Fullname: {user1.FullName}");
Console.WriteLine($"Department: {user1.Department}");
Console.WriteLine($"Role: {user1.Role}");
Console.WriteLine($"Phone number: {user1.Phone}\n\n");

Ticket ticket1 = new Ticket();

Console.WriteLine("TICKET + METHOD\n\n");

Console.WriteLine("Create a ticket.\n");
Console.Write("Subject: ");
ticket1.Subject = Console.ReadLine();

Console.Write("Description: ");
ticket1.Description = Console.ReadLine();

Console.Write("Status: ");
ticket1.Status = Console.ReadLine();

Console.Write("Severity: ");
ticket1.Severity = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"\nSubject: {ticket1.Subject}");
Console.WriteLine($"Description: {ticket1.Description}");
Console.WriteLine($"Status: {ticket1.Status}");
Console.WriteLine($"Status: {GetPriorityLabel(ticket1.Severity)}");


class Ticket
{
    public string Subject {get; set;}
    public string Description {get; set;}
    public string Status {get; set;}
    public int Severity {get; set;}
}

class User
{
    public string FullName {get; set;}
    public string Department {get; set;}
    public string Role {get; set;}
    public long Phone {get; set;}
}

