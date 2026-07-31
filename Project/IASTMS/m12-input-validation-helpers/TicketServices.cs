//Called out a module to utilize list
using System.Collections.Generic;
using System.Reflection.Metadata;

class TicketService
{
    //method to printout text
    private const string StatusOpen = "Open";
    private const string StatusInProgress = "In Progress";
    private const string StatusClosed = "Closed";
    
    private const string RoleAdmin = "Admin";
    private const string RoleTechnician = "Technician";
    private const string RoleViewer = "Viewer";

    private const string DeviceLenovo = "Lenovo";
    private const string DeviceMacBook = "Macbook";
    private const string DeviceHp = "HP";
    
    //This is a helper method to avoid repeating validations
    public int GetValidNumber(string message, int min, int max)
    {
        int number;
        while (true)
        {
            Console.Write(message);
            
            if (int.TryParse(Console.ReadLine(), out number) && number >= min && number <= max)
            {
                return number;
            }
            ShowInvalidInput();
        }
    }

    public bool GetValidBoolean(string message)
    {
        bool value;
        while (true)
        {
            Console.Write(message);
            
            if (bool.TryParse(Console.ReadLine(), out value))
            {
                return value;
            }
            ShowInvalidInput();
        }
    }

    public bool IsValidRole(string role)
    {
        return role == RoleAdmin || role == RoleTechnician || role == RoleViewer;
    }

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
        if(status == StatusOpen)
        {
            return "This ticket will now be worked on.";
        }
        else if (status == StatusInProgress){
            return "Ticket is now being handled.";
        }
        else if (status == StatusClosed){
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
        if(severity == 1 && (status == StatusOpen || status == StatusInProgress))
        {
            return "Urgent Active Ticket! We will investigate this issue immediately.";
        }
        else if(severity == 1 && status == StatusClosed)
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
        if(role == RoleAdmin || role == RoleTechnician )
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
        if(device == DeviceLenovo)
        {
            return "Kristian";
        }
        else if (device == DeviceMacBook)
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
                if (brand == DeviceLenovo || brand == DeviceMacBook || brand == DeviceHp)
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
            age = GetValidNumber("Age of Device (year(s)): ", 0, 100);

            //Verify correct input value of device damage status
            isDamaged = GetValidBoolean("Is the device damaged (True/False): ");


            // Verify the correct input value of severity
            severity = GetValidNumber("Ticket Severity (1|2|3): ", 1, 3);
            
            //verify the correct input value of status
            while (true)
            {
                Console.Write("Ticket Status (Open|In Progress|Closed): ");
                status = Console.ReadLine() ?? "";
                if (status == StatusOpen || status == StatusInProgress || status == StatusClosed )
                {
                    break;
                }
                else
                {
                    ShowInvalidInput();
                }
            }
            month = GetValidNumber("Month: ", 1, 12);
            day = GetValidNumber("Day: ", 1, 31);
            year = GetValidNumber("Year: ", 2000, 3000);
            
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
        if (tickets.Count == 0)
        {
            Console.WriteLine("No tickets are available.\n");
            return;
        }
        else
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
            int ticketNumber = GetValidNumber("Which ticket to update status: ", 1, 3000);

            int index = ticketNumber - 1;

            if(index >= 0 && index < tickets.Count)
            {
                string newStatus;
                while (true)
                {
                    Console.Write("Enter new status (Open/In Progress/Closed): ");
                    newStatus = Console.ReadLine() ?? "";

                    if (newStatus == StatusOpen || newStatus == StatusInProgress || newStatus == StatusClosed)
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
            int ticketNumber = GetValidNumber("Which ticket to delete: ", 1, 3000);
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