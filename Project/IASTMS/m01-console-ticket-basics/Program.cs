// Print out the App Title
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("IT Asset & Support Ticket Management System (IASTMS)");
Console.WriteLine();
Console.WriteLine();

// Collect user input for the ticket information
Console.WriteLine("Kindly File a Ticket Below");
Console.Write("Ticket Subject: ");
string subject = Console.ReadLine();
Console.Write("Ticket Description: ");
string description = Console.ReadLine();
Console.Write("Affected User: ");
string user  = Console.ReadLine();
Console.Write("Affected Device (Lenovo|MacBook|HP): " );
string device = Console.ReadLine();
Console.Write("Age of Device(years): ");
Console.Write("Ticket Severity (1|2|3): ");
int severity = Convert.ToInt32(Console.ReadLine());
Console.Write("Ticket Status (Open|In Progress|Closed): ");
string status = Console.ReadLine();
Console.WriteLine("Date of Issue Occurence (Numeric)");
Console.Write("Month: ");
int month = Convert.ToInt32(Console.ReadLine());
Console.Write("Day: ");
int day = Convert.ToInt32(Console.ReadLine());
Console.Write("Year: ");
int year = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();
Console.WriteLine();

// Notify user that the ticket has been created, ticket details for reference.
Console.WriteLine("Good Day! Thank you for filing a ticket. Your ticket number is ABC-123");
Console.WriteLine("Refer to the ticket details below");
Console.WriteLine();

Console.WriteLine($"Ticket Subject: {subject}");
Console.WriteLine($"Ticket Description: {description}");
Console.WriteLine($"Affected User: {user}");
Console.WriteLine($"Affected Device: {device}");
Console.WriteLine($"Ticket Severity: {severity}");
Console.WriteLine($"Ticket Status: {status}");
Console.WriteLine($"Date of Occurence (m/d/y): {month}/{day}/{year}");
Console.WriteLine();









