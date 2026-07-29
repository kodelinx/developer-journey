//Called out a module to utilize list
using System.Collections.Generic;

//Declare and initialize required objects
List<Ticket> tickets = new List<Ticket>();
TicketService ticketService = new TicketService();
bool keepRunning = true;

// Print out the App Title
ticketService.ShowAppTitle();

while (keepRunning)
{
    int option;
    //Prompt the ticket menu interface with action options
    ticketService.ShowMenu();
    //added a while loop to repetitively ask user to add a valid input until they got it right
    while (true)
    {
        // Ask the user to select a menu option.
        Console.Write("Choose from the options: ");
        // int.TryParse() safely checks whether the input can be converted to an integer
        // without crashing the application. The range check ensures that only menu
        // options from 1 to 7 are accepted. Valid input exits the loop; invalid input
        // displays an error and repeats.
        if (int.TryParse(Console.ReadLine(), out option) && option >= 1 && option <= 7)
        {
            break;
        }
        // Call a TicketService method to display an invalid-input message.
        ticketService.ShowInvalidInput();
 
    }
    Console.WriteLine();

    if(option == 1)
    {
        //Declare required variables
        int totalTicketCount;
        int counter = 1;
        string roleAccess;

        while (true)
        {
            //Identify total tickets to list out
            Console.Write("Indicate how many tickets: ");
            // Validation using a negative condition:
            // The input is invalid when it cannot be converted to an integer OR when the
            // number is zero or negative. Invalid input repeats the loop; valid input exits.
            if (!int.TryParse(Console.ReadLine(), out totalTicketCount) || totalTicketCount <= 0)
            {
                ticketService.ShowInvalidInput();
                continue;
            }
            break;
        }

        //Collect user input for the ticket information
        while(counter <= totalTicketCount)
        {

            //Identify if roleAccess input is correct
            while (true)
            {
                // Ask for and validate the user's role.
                Console.Write("What's your role (Admin/Technician/Viewer)? ");
                roleAccess = Console.ReadLine() ?? "";
                if(roleAccess == "Admin" || roleAccess == "Technician" || roleAccess == "Viewer")
                {
                    break;
                }

                ticketService.ShowInvalidInput();
            }

            //Call a class method
            ticketService.CreateTicket(tickets);

            int recentTicketNumber = tickets.Count - 1;
            // Notify user that the ticket has been created, ticket details for reference.
            //tickets.Count:000 prints out the total number of items in the list with a stanard format of 3 integers.
            Console.WriteLine($"Good Day! Thank you for filing a ticket. Your ticket number is ABC-{tickets.Count:000}");

            // Identify ticket status and the corresponding user notification.
            Console.WriteLine($"{ticketService.GetStatusNotification(tickets[recentTicketNumber].Status)}");

            //Identify device replacement
            Console.WriteLine($"{ticketService.GetDeviceAction(tickets[recentTicketNumber].Age, tickets[recentTicketNumber].IsDamaged)}");

            //Identify and notify ticket urgency
            Console.WriteLine($"{ticketService.GetUrgencyMessage(tickets[recentTicketNumber].Severity, tickets[recentTicketNumber].Status)}");
    
            //Identify ticket access based on roles
            Console.WriteLine($"{ticketService.GetRoleAccessMessage(roleAccess)}");

            Console.WriteLine();
            counter++;
        }  
    }
    else if (option == 2)
    {
        //Print out the ticket information
        ticketService.ViewAllTickets(tickets);
    }
    else if(option == 3)
    {
        //Search for a ticket
        ticketService.SearchTicket(tickets);
    }
    else if(option == 4)
    {
        //Update ticket status
        ticketService.UpdateTicketStatus(tickets);
        
    }
    else if(option == 5)
    {
        //Delete a ticket
       ticketService.DeleteTicket(tickets);
    }
    else if(option == 6)
    {
        //Provide total ticket count
        ticketService.ViewTicketCount(tickets);
    }

    else if (option == 7)
    {
        //Close program
        Console.WriteLine("Ticket Tracker has been closed.");
        keepRunning = false;
        Console.WriteLine();
    }
    else
    {
        //Indicate that option chosen is not valid
        Console.WriteLine("Please enter a valid option. Thank you!");
        Console.WriteLine();
    }
}

// Represents the data and behavior of a support ticket.
class Ticket
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
    //Added method in a class
    public string GetPriorityLabel()
    {
        if(Severity == 1)
        {
        return "High";
        }else if (Severity == 2)
        {
            return "Medium";
        }else if (Severity == 3)
        {
            return "Low";
        }
        else{
            return "Undefined";
        }

    }
}

class TicketService
{
    //method to printout text
    public void ShowAppTitle()
    {
        Console.WriteLine("\n\nIT Asset & Support Ticket Management System (IASTMS)\n");
    }
    public void ShowMenu()
    {
        Console.WriteLine("1. Create Ticket");
        Console.WriteLine("2. View All Tickets");
        Console.WriteLine("3. Search Ticket");
        Console.WriteLine("4. Update Ticket Status");
        Console.WriteLine("5. Delete Ticket");
        Console.WriteLine("6. View Ticket Count");
        Console.WriteLine("7. Exit");
        Console.WriteLine("");
    }
    // Return a notification based on the ticket status.
    public string GetStatusNotification(string status)
    {
        if(status == "Open")
        {
            return "This ticket will now be worked on.";
        }
        else if (status == "In Progress"){
            return "Ticket is now being handled.";
        }
        else if (status == "Closed"){
            return "Ticket has already been resolved.";
        }
        else{
            return "Unknown Status.";
        }
    }
    public string GetDeviceAction(int deviceAge, bool deviceDamaged)
    {
        if(deviceAge > 2 || deviceDamaged)
        {
            return "Replacement is recommended.";
        }
        else
        {
            return "Proceed to troubleshooting.";
        }
    }
    public string GetUrgencyMessage(int severity, string status)
    {
        if(severity == 1 && (status == "Open" || status == "In Progress"))
        {
            return "Urgent Active Ticket! We will investigate this issue immediately.";
        }
        else if(severity == 1 && status == "Closed")
        {
            return "Urgent but already resolved";
        }
        else
        {
            return "Regular Ticket";
        }

    }
    public string GetRoleAccessMessage(string role)
    {
        if(role == "Admin" || role == "Technician")
        {
        return "Please work on the Ticket and provide updates!";
        }
        else
        {
            return  "You can only view this ticket.";
        }
    }
    public void ShowInvalidInput()
    {
        Console.WriteLine("Incorrect input. Please try again!\n");
    }
    public string GetTechnician(string device)
    {
        if(device == "Lenovo")
        {
            return "Kristian";
        }
        else if (device == "MacBook")
        {
            return "Dave";
        }
        else
        {
            return "KD";
        }
    }
    private void DisplayTicket(Ticket ticket, int ticketNumber)
    {
        Console.WriteLine($"TICKET NUMBER {ticketNumber}");
        Console.WriteLine($"Ticket Subject: {ticket.Subject}");
        Console.WriteLine($"Ticket Description: {ticket.Description}");
        Console.WriteLine($"Affected User: {ticket.AffectedUser}");
        Console.WriteLine($"Affected Device: {ticket.Brand}");

        // Assign a technician will takeover this ticket based on the device affected.
        Console.WriteLine($"Technician: {GetTechnician(ticket.Brand)}");

        // Designate priority level based on indicated severity
        //Called a method from a class ticket
        Console.WriteLine($"Ticket Priority: {ticket.GetPriorityLabel()} - {ticket.Severity}");

        Console.WriteLine($"Ticket Status: {ticket.Status}");
        Console.WriteLine($"Date of Occurrence (m/d/y): {ticket.Month}/{ticket.Day}/{ticket.Year}\n");
    }
    public void CreateTicket(List<Ticket> tickets)
    {
            string status, brand;
            int severity, age, day, month, year;
            bool isDamaged;

            Console.WriteLine("\nKindly File a Ticket Below");
            Console.Write("Ticket Subject: ");
            string subject = Console.ReadLine() ?? "";
            Console.Write("Ticket Description: ");
            string description = Console.ReadLine() ?? "";
            Console.Write("Affected User: ");
            string affectedUser  = Console.ReadLine() ?? "";

            //Verify correct input value of Device
            while (true)
            {
                Console.Write("Affected Device (Lenovo|MacBook|HP): " );
                brand= Console.ReadLine() ?? "";
                if (brand == "Lenovo" || brand == "MacBook" || brand == "HP")
                {
                    break;
                }  
                else
                {
                    ShowInvalidInput();
                }
            }

            // compact validation inside the while condition:
            // Continue looping while the input is not an integer OR the age is negative.
            Console.Write("Age of Device (year(s)): ");

            while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
            {
                ShowInvalidInput();
                Console.Write("Age of Device (year(s)): ");
            }

            //Verify correct input value of device damage status
            while (true)
            {
                Console.Write("Is the device damaged (True/False)? ");
                if (bool.TryParse(Console.ReadLine(), out isDamaged))
                {
                    break;   
                }
                ShowInvalidInput();
            }

            // Verify the correct input value of severity
            while (true)
            {
                Console.Write("Ticket Severity (1|2|3): ");
                if(!int.TryParse(Console.ReadLine(), out severity) || severity < 1 || severity > 3)
                {
                    ShowInvalidInput();
                    continue;
                }
                break;
            }
            
            //verify the correct input value of status
            while (true)
            {
                Console.Write("Ticket Status (Open|In Progress|Closed): ");
                status = Console.ReadLine() ?? "";
                if (status == "Open" || status == "In Progress" || status == "Closed" )
                {
                    break;
                }
                else
                {
                    ShowInvalidInput();
                }
            }
            while (true)
            {
                Console.Write("Month: ");
                if(!int.TryParse(Console.ReadLine(), out month)|| month < 1 || month > 12)
                {
                    ShowInvalidInput();
                    continue;
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                Console.Write("Day: ");
                if(!int.TryParse(Console.ReadLine(), out day) || day < 1 || day > 31)
                {
                    ShowInvalidInput();
                    continue;
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                Console.Write("Year: ");
                if(!int.TryParse(Console.ReadLine(), out year) || year < 2000)
                {
                    ShowInvalidInput();
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine();
            Console.WriteLine();

            //utilized the constructor to pass arguments to class parameters
            Ticket ticket = new Ticket(subject, description, status, severity, month, day, year, brand, age, isDamaged, affectedUser);
            tickets.Add(ticket);

            Console.WriteLine("Ticket created successfully!");
    }

    public void ViewAllTickets(List<Ticket> tickets)
    {
        if (tickets.Count > 0)
        {
            //Print out the ticket information
            Console.WriteLine("Refer to the ticket details below:");
            Console.WriteLine();
            for(int i = 0; i < tickets.Count; i++)
            {
                DisplayTicket(tickets[i], i+1);
            }  
        }
        else
        {
            Console.WriteLine("No ticket has been created yet.");
        }
        Console.WriteLine();
    }
    public void SearchTicket(List<Ticket> tickets)
    {
        Console.Write("Enter Ticket Subject: ");
        string searchSubject = Console.ReadLine() ?? "";

        bool found = false;

        for (int i = 0; i < tickets.Count; i++)
        {
            if (tickets[i].Subject.Equals(searchSubject, StringComparison.OrdinalIgnoreCase))
            {
                DisplayTicket(tickets[i], i + 1);
                found = true;
                break;
            }
        }
        if (!found)
        {
            Console.WriteLine("\nNo ticket with that subject was found.\n");
        }
    }
    public void UpdateTicketStatus(List<Ticket>  tickets)
    {
        if (tickets.Count == 0)
        {
            Console.WriteLine("No tickets are available.\n");
            return;
        }
        else
        {
            int ticketNumber;

            while (true)
            {
                //Identify which ticket to update status
                Console.Write("Which ticket to update status: ");
                if (!int.TryParse(Console.ReadLine(), out ticketNumber))
                {
                    Console.WriteLine("Please enter a valid number. \n");
                    continue;
                }
                else
                {
                    break;
                }
            }

            int index = ticketNumber - 1;

            if(index >= 0 && index < tickets.Count)
            {
                string newStatus;
                while (true)
                {
                    Console.Write("Enter new status (Open/In Progress/Closed): ");
                    newStatus = Console.ReadLine() ?? "";

                    if (newStatus == "Open" || newStatus == "In Progress" || newStatus == "Closed")
                    {
                        break;
                    }

                    ShowInvalidInput();
                }
                tickets[index].Status = newStatus;
                Console.WriteLine("Ticket status updated successfully.\n");
    
            }
            else
            {
                Console.WriteLine("\nThe ticket is not existing.\n");
            }
        }
     
    }
    public void DeleteTicket(List<Ticket> tickets)
    {
        if (tickets.Count == 0)
        {
            Console.WriteLine("No tickets are available.\n");
            return;
        }
        else
        {
            int ticketNumber;
            while (true)
            {
                Console.Write("Which ticket to delete: ");
                if(!int.TryParse(Console.ReadLine(), out ticketNumber))
                {
                    Console.WriteLine("Please enter a valid number.\n");
                    continue;
                }
                else
                {
                    break;
                }
            }
            int index = ticketNumber - 1;
            if(index >= 0 && index < tickets.Count)
            {
                tickets.RemoveAt(index);
                Console.WriteLine("Ticket has been deleted.\n");
            }
            else
            {
                Console.WriteLine("\nThe ticket is not existing.\n");
            }
        }
    }
    public void ViewTicketCount(List<Ticket> tickets)
    {
        Console.WriteLine($"There is a total of {tickets.Count} tickets.\n");
    }
}









