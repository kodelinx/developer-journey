using System.Collections.Generic;

List<Ticket> tickets = new List<Ticket>();

//added tickets item
tickets.Add(new Ticket("Laptop issue", "Open"));
tickets.Add(new Ticket("Printer issue", "In Progress"));
tickets.Add(new Ticket("Network issue", "Open"));


Console.WriteLine("\n==TICKET==\n");

//iterates items using list index, system uses for loop 
for (int i = 0; i < tickets.Count; i++)
{
    Console.WriteLine($"{i + 1}. {tickets[i].Subject} - {tickets[i].Status}");
}

Console.WriteLine("\nADD TICKET\n");

Console.Write("Input Subject: ");
string subject = Console.ReadLine();
Console.Write("Input Status: ");
string status = Console.ReadLine();

tickets.Add (new Ticket(subject, status));

for (int i = 0; i < tickets.Count; i++)
{
    Console.WriteLine($"{i + 1}. {tickets[i].Subject} - {tickets[i].Status}");
}


Console.WriteLine("\nUPDATE TICKET\n");

Console.Write("Choose ticket number to update: ");
int ticketNumber = Convert.ToInt32(Console.ReadLine());
//since list starts as [0] but our list is assigned to start as 1, we deduct 1  from  user input to allow our system to accurately read the choosen option (e.g. user inputs 2-> system reads it as [1])
int index = ticketNumber - 1;
//ensures that the users utilizes
if (index >= 0 && index < tickets.Count)
{
    Console.Write("Enter new status: ");
    string newStatus = Console.ReadLine();

    tickets[index].Status = newStatus;

    Console.WriteLine("Ticket status updated.");
}
else
{
    Console.WriteLine("Invalid ticket number.");
}

Console.WriteLine();
Console.WriteLine("=== Updated Tickets ===");

for (int i = 0; i < tickets.Count; i++)
{
    Console.WriteLine($"{i + 1}. {tickets[i].Subject} - {tickets[i].Status}");
}


Console.WriteLine("\nSEARCH TICKET");

Console.Write("Search for a ticket subjec: ");
string searchItem = Console.ReadLine();

bool found = false;

foreach(Ticket ticket in tickets)
{
    if(searchItem == ticket.Subject)
    {
        Console.WriteLine($"{ticket.Subject}");
        found = true;
    }
}

if (!found)
{
    Console.WriteLine("Ticket not found");
}


Console.WriteLine("\nDELETE TICKET\n");

Console.Write("Choose an item to delete: ");
int deleteItem = Convert.ToInt32(Console.ReadLine());

index = deleteItem -1;

if(index >= 0 && index < tickets.Count)
{
    tickets.RemoveAt(index);
    //once deleted, the latest item in the list after the deleted item will replace its position
    //e.g. 1. Laptop issue has been deleted. 1. will be replaced with Printer issue and all succeeding items will follow.
    Console.WriteLine("Ticket deleted.");
}
else
{
    Console.WriteLine("Invalid Ticket Number");
}

for(int i = 0; i < tickets.Count;  i++)
{
    Console.WriteLine($"{i + 1}.  {tickets[i].Subject}: {tickets[i].Status}");
}

class Ticket
{
    public string Subject { get; set; }
    public string Status { get; set; }

    public Ticket(string subject, string status)
    {
        Subject = subject;
        Status = status;
    }
}
