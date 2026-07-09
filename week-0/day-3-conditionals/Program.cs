Console.WriteLine("TICKET STATUS INDICATOR");
Console.WriteLine();

Console.Write("Input ticket status (Open, In Progress, Closed): ");
string status = Console.ReadLine();

if(status == "Open"){
    Console.WriteLine("Ticket is newly created");
}
else if (status == "In Progress"){
    Console.WriteLine("Ticket is being handled");
}
else if (status == "Closed"){
    Console.WriteLine("Ticket is already resolved");
}
else{
    Console.WriteLine("Unknown Status");
}

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("PASS OR FAIL EXERCISE");
Console.WriteLine();

Console.Write("Please indicate your score: ");
double score = Convert.ToDouble(Console.ReadLine());
Console.WriteLine();

if(score >= 75)
{
    Console.WriteLine("Passed");
}
else{
    Console.WriteLine("Failed");
}

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("TICKET PRIORITY INDICATOR");
Console.WriteLine();

Console.Write("Indicate Ticket Severity (1,2,3): ");
int severity = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();

if(severity == 1)
{
    Console.WriteLine("High priority: Handle Immediately");
}
else if(severity == 2)
{
    Console.WriteLine("Medium Priority: Handle within the day");
}
else if(severity == 3)
{
    Console.WriteLine("Low priority: Can be handled later");
}
else
{
    Console.WriteLine("Invalid Priority");
}

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Device Warranty Checker");
Console.WriteLine();

Console.Write("How many years old is the device? ");
double years = Convert.ToDouble(Console.ReadLine());
Console.WriteLine();

if(years >= 0 && years <= 2)
{
    Console.WriteLine("Under Warranty");
}
else if(years >=3 && years <=5)
{
    Console.WriteLine("For monitoring");
}
else
{
    Console.WriteLine("Recommend replacement");
}