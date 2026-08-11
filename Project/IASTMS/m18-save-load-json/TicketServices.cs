using System.Security.Permissions;
using System.Collections.Generic;
using System.Text.Json;

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
    private const string DeviceMacBook = "MacBook";
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

    public string GetValidStatus(string message)
    {
        while (true)
        {
            string status = GetRequiredText(message);

            if (status == StatusOpen || status == StatusInProgress || status == StatusClosed)
            {
                return status;
            }
            ShowInvalidInput();
        }
    }
    public string GetValidDeviceBrand(string message)
    {
            while (true)
            {
                string brand= GetRequiredText(message);
                if (brand == DeviceLenovo || brand == DeviceMacBook || brand == DeviceHp)
                {
                    return brand;
                }  
                ShowInvalidInput();

            }
    }
    public bool IsValidRole(string role)
    {
        return role == RoleAdmin || role == RoleTechnician || role == RoleViewer;
    }

    public string GetValidRole(string message)
    {
        while (true)
        {
            // Ask for and validate the user's role.
            string role = GetRequiredText(message);
            if(IsValidRole(role))
            {
                return role;
            }
            ShowInvalidInput();
        }

    }

    //Utilizes a tuple method returinign multiple values
    private (int month, int day, int year) GetTicketDate()
    {
        int month = GetValidNumber("Month: ", 1, 12);
        int day = GetValidNumber("Day: ", 1, 31);
        int year = GetValidNumber("Year: ", 2000, 3000);

        return(month, day, year);
    }

    // method to check null, empty, and a valid data type
    public string GetRequiredText(string message)
    {
        while (true)
        {
            Console.Write(message);
            //string? allows value type to be null
            string? value = Console.ReadLine();
            // checks and ensures whether value is null, "", or "   " before returning a value.
            if (!string.IsNullOrWhiteSpace(value))
            {
                //trims of any white spacess before and after the inputted string
                return value.Trim();
            }
            ShowInvalidInput();
        }
    }
    public string GetPriorityLabel(int severity)
    {
        if(severity == 1)
        {
        return "High";
        }else if (severity == 2)
        {
            return "Medium";
        }else if (severity == 3)
        {
            return "Low";
        }
        else{
            return "Undefined";
        }

    }
    // void methods  does  not  return any data, only runs an action
    public void ShowAppTitle()
    {
        Console.WriteLine("\n\nIT Asset & Support Ticket Management System (IASTMS)\n");
    }
        public void ShowInvalidInput()
    {
        Console.WriteLine("Incorrect input. Please try again!\n");
    }
    public void ShowMenu()
    {
        Console.WriteLine("1. Create Ticket");
        Console.WriteLine("2. View All Tickets");
        Console.WriteLine("3. Search Ticket");
        Console.WriteLine("4. Update Ticket Status");
        Console.WriteLine("5. Delete Ticket");
        Console.WriteLine("6. View Ticket Count");
        Console.WriteLine("7. Save Tickets as Text File");
        Console.WriteLine("8. Load Tickets from Text File");        
        Console.WriteLine("9. Save Tickets as JSON file");
        Console.WriteLine("10. Load Tickets from JSON file");  
        Console.WriteLine("11. Exit");
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
        Console.WriteLine($"Ticket Priority: {GetPriorityLabel(ticket.Severity)} - {ticket.Severity}");

        Console.WriteLine($"Ticket Status: {ticket.Status}");
        Console.WriteLine($"Date of Occurrence (m/d/y): {ticket.Month}/{ticket.Day}/{ticket.Year}\n");
    }
    public void CreateTicket(List<Ticket> tickets)
    {
            string status, brand;
            int severity, age;
            bool isDamaged;

            Console.WriteLine("\nKindly File a Ticket Below");
            string subject = GetRequiredText("Ticket Subject: ");;
            string description = GetRequiredText("Ticket Description: ");;
            string affectedUser  = GetRequiredText("Affected User: ");

            //Verify correct input value of Device
            brand = GetValidDeviceBrand("Affected Device (Lenovo|MacBook|HP): ");

            // compact validation inside the while condition:
            // Continue looping while the input is not an integer OR the age is negative.
            age = GetValidNumber("Age of Device (year(s)): ", 0, 100);

            //Verify correct input value of device damage status
            isDamaged = GetValidBoolean("Is the device damaged (True/False): ");


            // Verify the correct input value of severity
            severity = GetValidNumber("Ticket Severity (1|2|3): ", 1, 3);
            
            //verify the correct input value of status
            status = GetValidStatus("Ticket Status (Open|In Progress|Closed): ");
            
            var ticketDate = GetTicketDate();
            
            Console.WriteLine();
            Console.WriteLine();

            //utilized the constructor to pass arguments to class parameters
            Ticket ticket = new Ticket(subject, description, status, severity, ticketDate.month, ticketDate.day, ticketDate.year, brand, age, isDamaged, affectedUser);
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

        string searchSubject = GetRequiredText("Enter Ticket Subject: ");

        bool found = false;

        for (int i = 0; i < tickets.Count; i++)
        {
            if (tickets[i].Subject.Contains(searchSubject, StringComparison.OrdinalIgnoreCase))
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

        int ticketNumber = GetValidNumber("Which ticket to update status: ", 1, 3000);

        int index = ticketNumber - 1;

        if(index >= 0 && index < tickets.Count)
        {
            tickets[index].Status = GetValidStatus("Enter new status (Open/In Progress/Closed): ");
            Console.WriteLine("Ticket status updated successfully.\n");
        }
        else
        {
            Console.WriteLine("\nThe ticket is not existing.\n");
        }
     
    }
    public void DeleteTicket(List<Ticket> tickets)
    {
        if (tickets.Count == 0)
        {
            Console.WriteLine("No tickets are available.\n");
            return;
        }

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
    public void SaveTicketsToTextFile(List<Ticket> tickets)
    {
        //check if tickets are available for  saving
        if (tickets.Count == 0)
        {
            Console.WriteLine("No tickets are available to save \n");
            return;
        }
        //stores the  saved tickets
        string filePath = "tickets.txt";
        List<string> lines = new List<string>();

        foreach(Ticket ticket in tickets)
        {
            //formatted with a character | as a delimmitter to be utilized by LoadTicketsFromTextFile() method
            string line = $"{ticket.Subject}|{ticket.Description}|{ticket.Status}|{ticket.Severity}|{ticket.Month}|{ticket.Day}|{ticket.Year}|{ticket.Brand}|{ticket.Age}|{ticket.IsDamaged}|{ticket.AffectedUser}";
            lines.Add(line);
        }

        try
        {
            File.WriteAllLines(filePath, lines);
            Console.WriteLine($"Tickets are saved successfully to {filePath}\n");
        }
        catch(Exception error)
        {
            Console.WriteLine("An error occured while saving tickets");
            Console.WriteLine($"Error details: {error.Message}");
        }

    }
    public void LoadTicketsFromTextFile(List<Ticket> tickets)
    {
        //store the name of the text file containing the saved tickets
        string filePath = "tickets.txt";
        // File.Exists() checks whether the specified file exists.
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No saved ticket file was found.");
            return;
        }

        try
        {
            //[] means an array. In this case, an array of strings of object lines
            //File.ReadAllLines iterates  and reads all  line in filePath
            string[] lines = File.ReadAllLines(filePath);

            //Remove existing tickets from the current list before loading
            tickets.Clear();

            foreach (string line in lines)
            {
                //.Split() separate one string into multiple pieces
                // The character  | acts as the delimeterseparator
                string[] parts = line.Split('|');

                // checks if all fields exists in the ticket, if not, skip the record
                if(parts.Length != 11)
                {
                    Console.WriteLine("A saved ticket record was skipped because it has an invalid format");
                    continue;
                }

                string subject = parts[0];
                string description = parts[1];
                string status = parts[2];
                int severity = int.Parse(parts[3]);
                int month = int.Parse(parts[4]);
                int day = int.Parse(parts[5]);
                int year = int.Parse(parts[6]);
                string brand = parts[7];
                int age = int.Parse(parts[8]);
                bool isDamaged = bool.Parse(parts[9]);
                string affectedUser = parts[10];

                Ticket ticket = new Ticket(
                subject,
                description,
                status,
                severity,
                month,
                day,
                year,
                brand,
                age,
                isDamaged,
                affectedUser
                );

                tickets.Add(ticket);
            }
            Console.WriteLine($"Tickets has been loaded  successfully from {filePath}");
        }
        catch(Exception error)
        {
            Console.WriteLine("An error occured while loading tickets");
            Console.WriteLine($"Error details: {error.Message}");
        }
    }

    public void SaveTicketToJson(List<Ticket> tickets)
    {
        if(tickets.Count == 0)
        {
            Console.WriteLine("No tickets are available to save.");
            return;
        }
        
        string filePath = "tickets.json";

        // File operations and JSON serialization can potentiall fail
        try
        {
            // Create an object containing configuration/settings that control how JsonSerializer createes the JSON
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                // Format the JSON usin indentation and line breaks so the saved file is easier for humans to read
                WriteIndented = true
            };

            // Serialize() converts the List<Ticket> object into JSON text
            // The options object tells the serailizer to format the JSON neatly
            string json = JsonSerializer.Serialize(tickets, options);
            
            // WriteAllText() writes the entire JSON string into the specfied file
            // It writes a file or overwrites an existing one
            File.WriteAllText(filePath, json);

            Console.WriteLine($"Tickets saved successfullyto {filePath}. \n");
        }
        catch(Exception error)
        {
            Console.WriteLine("An error occured saving tickets.");
            Console.WriteLine($"Error details: {error.Message}");
        }  
    }

    public void LoadTicketsFromJsonFile(List<Ticket> tickets)
    {
        string filePath = "tickets.json";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("No saved JSON ticket file was found.\n");
            return;
        }

        try
        {
            // ReadAllText() reads the entire ontents of tickets.json and stroes it as one string
            string json = File.ReadAllText(filePath);

            // Deserialize() converts the JSON string back into C# objects
            // ? means loadedTickets is allowed to contain null because deserialization can potentiall return null.
            List<Ticket>? loadedTickets = JsonSerializer.Deserialize<List<Ticket>>(json);
            
            // Check whether deserialization produced a usable list
            if (loadedTickets == null)
            {
                Console.WriteLine("No ticket data was loaded.\n");
                return;
            }

            tickets.Clear();

            //Add every Ticket object ffrom loadedTickets into the existing tickets list
            tickets.AddRange(loadedTickets);

            Console.WriteLine("Tickets loaded successfully from JSON file.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while loading tickets.");
            Console.WriteLine($"Error details: {ex.Message}\n");
        }
    }

    public void ViewTicketCount(List<Ticket> tickets)
    {
        Console.WriteLine($"There is a total of {tickets.Count} tickets.\n");
    }
}