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
Console.Write("Ticket Severity (1|2|3): ");
int severity = Convert.ToInt32(Console.ReadLine());
Console.Write("Ticket Status (Open|In Progress|Closed0): ");
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
// Decide which technician will takeover this ticket based on the device affected.
if(device == "Lenovo"){
    Console.WriteLine("Technician: Kristian");
}else if (device == "MacBook"){
    Console.WriteLine("Technician: Dave");
}else{
    Console.WriteLine("Technician: KD");
}
Console.WriteLine($"Ticket Status: {status}");
Console.WriteLine($"Date of Occurence: {month}/{day}/{year}");
Console.WriteLine();
// Identify ticket status and the corresponding user notification.
if(status == "Open"){
    Console.WriteLine("Newly created ticket");
}else if (status == "In Progress"){
    Console.WriteLine("Ticket is being handled");
}else if (status == "Closed"){
    Console.WriteLine("Ticket is already resolved");
}else{
    Console.WriteLine("Unknown Status");
}
Console.WriteLine();


