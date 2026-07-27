//Sample Refactoring Practice

using System.Collections.Generic;

List<Ticket> tickets = new List<Ticket>();

bool keepRunning = true;

while (keepRunning)
{
    ShowMenu();

    int option = Convert.ToInt32(Console.ReadLine());

    if (option == 1)
    {
        //created a method to simplify the program
        CreateTicket(tickets);
    }
    else if (option == 2)
    {
        ViewAllTickets(tickets);
    }
    else if (option == 3)
    {
        ViewTicketCount(tickets);
    }
    else if (option == 4)
    {
        Console.WriteLine("Program closed.");
        keepRunning = false;
    }
    else
    {
        Console.WriteLine("Invalid option.");
    }

    Console.WriteLine();
}

static void ShowMenu()
{
    Console.WriteLine("=== Ticket Menu ===");
    Console.WriteLine("1. Create Ticket");
    Console.WriteLine("2. View All Tickets");
    Console.WriteLine("3. View Ticket Count");
    Console.WriteLine("4. Exit");
    Console.Write("Choose an option: ");
}
//adding parameters for a list
static void CreateTicket(List<Ticket> tickets)
{
    Console.Write("Enter subject: ");
    string subject = Console.ReadLine();

    Console.Write("Enter status: ");
    string status = Console.ReadLine();

    Ticket ticket = new Ticket(subject, status);

    tickets.Add(ticket);

    Console.WriteLine("Ticket created successfully.");
}

static void ViewAllTickets(List<Ticket> tickets)
{
    if (tickets.Count == 0)
    {
        Console.WriteLine("No tickets have been created yet.");
        return;
    }

    Console.WriteLine("=== All Tickets ===");

    for (int i = 0; i < tickets.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {tickets[i].Subject} - {tickets[i].Status}");
    }
}

static void ViewTicketCount(List<Ticket> tickets)
{
    Console.WriteLine($"Total Tickets: {tickets.Count}");
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