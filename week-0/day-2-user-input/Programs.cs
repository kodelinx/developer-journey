Console.WriteLine("Developer Journey: Week 0 Day 2");
Console.WriteLine("Input CHARACTERS");
//Displays space for text input on the same line
Console.Write("Name: ");
//Assign the input text to "name" object
string name = Console.ReadLine();
Console.Write("Goal: ");
string goal = Console.ReadLine();

Console.WriteLine();
//Prints the output, {} allows you to call out the content of the object
Console.WriteLine($"Hello {name}, your objective for today is to {goal}. Enjoy!");

Console.WriteLine();
Console.WriteLine("Input Integers");
Console.Write("How many hours can you dedicate per day: ");
//Console.ReadLine() always produces a string
//Code below converts that string to the respective data type assigned, which is "int"
int hoursPerDay = Convert.ToInt32(Console.ReadLine());
Console.Write("How many months do you aim to be ready: ");
int months = Convert.ToInt32(Console.ReadLine());

Console.WriteLine();
Console.WriteLine($"You will be studying for {hoursPerDay} hours a day for {months} months");

Console.WriteLine();
Console.WriteLine("PROJECT APPLICATION");
Console.WriteLine("IT Asset Management & Ticketing System");
Console.WriteLine("Create a ticket below")
Console.Write("Enter Subject: ");
string subject = Console.ReadLine();
Console.Write("Enter Description: ");
string description = Console.ReadLine();
Console.Write("Enter Severity: ");
int sev = Convert.ToInt32(Console.ReadLine());
Console.Write("Assign Technician: ");
string technician = Console.ReadLine();

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("TICKET CREATED!")
Console.WriteLine($"Thank you for reaching out. Please refer to your ticket number ABC-001 and we wil work on this out.");

Console.WriteLine();
Console.WriteLine($"Ticket Subject: {subject}");
Console.WriteLine($"Ticket Description: {description}");
Console.WriteLine($"Ticket Severity: {sev} ");
Console.WriteLine();
Console.WriteLine($"Hello, I'm {technician}, I'll be supporting you on this case.");

Console.Write("Rate my output: ");
//double is a data type variable
double rating = Convert.ToDouble(Console.ReadLine());

Console.WriteLine();
Console.WriteLine($"Thank you for your rating of {rating}!");



