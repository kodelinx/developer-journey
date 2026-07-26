//Called out a module to utilize list
using System.Collections.Generic;

//Declaration and initialization of objects required
Ticket ticketItem;
List<Ticket> tickets = new List<Ticket>();

int option;
bool keepRunning = true;

//method to printout text
static void ShowAppTitle()
{
    Console.WriteLine("\n\nIT Asset & Support Ticket Management System IASTMS\n");
}
static void ShowMenu()
{
    Console.WriteLine("1. Create Ticket");
    Console.WriteLine("2. View All Tickets");
    Console.WriteLine("3. Search Ticket");
    Console.WriteLine("4. Update Ticket Status");
    Console.WriteLine("5. Delete Ticket");
    Console.WriteLine("6. View Ticket Count");
    //Console.WriteLine("3. Check Ticket Urgency");
    Console.WriteLine("7. Exit");
    Console.WriteLine("");
}
static void ShowInvalidInput()
{
    Console.WriteLine("Incorrect input. Please try again!\n");
}
//method to returns a value
static string GetTechnician(string device)
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
static string GetStatusNotification(string status)
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
static string GetDeviceAction(int deviceAge, bool deviceDamaged)
{
    if(deviceAge > 2 || deviceDamaged)
    {
        return "Replacement is recommended.";
    }
    else
    {
        return "Proceed to Troubleshooting.";
    }
}
static string GetUrgencyMessage(int severity, string status)
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
static string GetRoleAccessMessage(string role)
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
static bool GetDeviceDamageStatus(string input)
{
    if(input == "True")
    {
        return true;
    }
    else
    {
        return false;
    }
}

// Print out the App Title
ShowAppTitle();

tickets.Add(new Ticket("subject1", "description1","Open",3,1,1,2026,"Lenovo",5,true,"Dave","Admin"));
tickets.Add(new Ticket("subject2", "description2","Close",1,2,2,2026,"HP",5,true,"Hera","Viewer"));


while (keepRunning)
{
    ShowMenu();

    Console.Write("Choose from the options: ");
    option = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    if(option == 1)
    {
        //Declare required variables
        string roleAccess;
        int severity;
        string subject;
        string description;
        string affectedUser;
        string brand;
        int age;
        string input;
        bool isDamaged;
        string status;
        int totalTicketCount;
        int month;
        int day;
        int year;
        int counter = 1;

        //Identify total tickets to list out
        Console.Write("Indicate how many tickets: ");
        totalTicketCount = Convert.ToInt32(Console.ReadLine());

        //Collect user input for the ticket information
        while(counter <= totalTicketCount)
        {
            while (true)
            {
                //Verify correct input value of role
                Console.Write("What's your role (Admin/Technician/Viewer)? ");
                roleAccess = Console.ReadLine();
                if(roleAccess == "Admin" || roleAccess == "Technician" || roleAccess == "Viewer")
                {
                    break;
                }
                else
                {
                    ShowInvalidInput();
                }
            }
            Console.WriteLine("\nKindly File a Ticket Below");
            Console.Write("Ticket Subject: ");
            subject = Console.ReadLine();
            Console.Write("Ticket Description: ");
            description = Console.ReadLine();
            Console.Write("Affected User: ");
            affectedUser  = Console.ReadLine();

            //Verify correct input value of Device
            while (true)
            {
                Console.Write("Affected Device (Lenovo|MacBook|HP): " );
                brand= Console.ReadLine();
                if (brand == "Lenovo" || brand == "MacBook" || brand == "HP")
                {
                break;
                }  
                else
                {
                    ShowInvalidInput();
                }
            }

            Console.Write("Age of Device(year(s)): ");
            age = Convert.ToInt32(Console.ReadLine());

            //Verify correct input value of device damage status
            while (true)
            {
                Console.Write("Is the device damaged (True/False)? ");
                input = Console.ReadLine();
                if (input == "True" || input == "False")
                {
                    isDamaged = GetDeviceDamageStatus(input);
                    break;
                }
                else
                {
                    ShowInvalidInput();
                }
            }

            //Verify the correct input value of severity
            while (true)
            {
                Console.Write("Ticket Severity (1|2|3): ");
                severity = Convert.ToInt32(Console.ReadLine());
                if (severity >= 1 && severity <=3)
                {
                    break;
                }
                else
                {
                    ShowInvalidInput();
                }
            }
            //verify the correct input value of status
            while (true)
            {
                Console.Write("Ticket Status (Open|In Progress|Closed): ");
                status = Console.ReadLine();
                if (status == "Open" || status == "In Progress" || status == "Closed" )
                {
                    break;
                }
                else
                {
                    ShowInvalidInput();
                }
            }
            Console.WriteLine("Date of Issue Occurence (Numeric)");
            Console.Write("Month: ");
            month = Convert.ToInt32(Console.ReadLine());
            Console.Write("Day: ");
            day = Convert.ToInt32(Console.ReadLine());
            Console.Write("Year: ");
            year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine();

            //utilized the constructor to pass arguments to class parameters
            ticketItem = new Ticket(subject, description, status, severity, month, day, year, brand, age, isDamaged, affectedUser, roleAccess);


            // Notify user that the ticket has been created, ticket details for reference.
            Console.WriteLine("Good Day! Thank you for filing a ticket. Your ticket number is ABC-123");

            // Identify ticket status and the corresponding user notification.
            Console.WriteLine($"{GetStatusNotification(ticketItem.Status)}");

            //Identify device replacement
            Console.WriteLine($"{GetDeviceAction(ticketItem.Age, ticketItem.isDamaged)}");

            //Identify and notify ticket urgency
            Console.WriteLine($"{GetUrgencyMessage(ticketItem.Severity, ticketItem.Status)}");
    
            //Identify ticket access based on roles
            Console.WriteLine($"{GetRoleAccessMessage(ticketItem.RoleAccess)}");

            Console.WriteLine();
            //Add each ticketItem created to the tickets list
            tickets.Add(ticketItem);
            counter++;
        }
        

       
    }
    else if (option == 2)
    {
        if (tickets.Count > 0)
        {
            //Print out the ticket information
            Console.WriteLine("Refer to the ticket details below:");
            Console.WriteLine();
            for(int i = 0; i < tickets.Count; i++)
            {
                Console.WriteLine($"TICKET NUMBER {i + 1}");
                Console.WriteLine($"Ticket Subject: {tickets[i].Subject}");
                Console.WriteLine($"Ticket Description: {tickets[i].Description}");
                Console.WriteLine($"Affected User: {tickets[i].AffectedUser}");
                Console.WriteLine($"Affected Device: {tickets[i].Brand}");

                // Assign a technician will takeover this ticket based on the device affected.
                Console.WriteLine($"Technician: {GetTechnician(tickets[i].Brand)}");

                // Designate priority level based on indicated severity
                //Called a method from a class ticket
                Console.WriteLine($"Ticket Priority: {tickets[i].GetPriorityLabel()} - {tickets[i].Severity}");

                Console.WriteLine($"Ticket Status: {tickets[i].Status}");
                Console.WriteLine($"Date of Occurence (m/d/y): {tickets[i].Month}/{tickets[i].Day}/{tickets[i].Year}\n");
            }
        }
        else
        {
            Console.WriteLine("No ticket has been created yet.");
        }
        Console.WriteLine();
        
    }
    else if(option == 3)
    {
        //Search for a ticket
        Console.Write("Enter Ticket Subject: ");
        string searchSubject = Console.ReadLine();

        bool found = false;

        foreach(Ticket ticket in tickets)
        {
            if  (ticket.Subject == searchSubject)
            {
                Console.WriteLine($"\nTicket Subject: {ticket.Subject}");
                Console.WriteLine($"Ticket Description: {ticket.Description}");
                Console.WriteLine($"Affected User: {ticket.AffectedUser}");
                Console.WriteLine($"Affected Device: {ticket.Brand}");

                // Assign a technician will takeover this ticket based on the device affected.
                Console.WriteLine($"Technician: {GetTechnician(ticket.Brand)}");

                // Designate priority level based on indicated severity
                //Called a method from a class ticket
                Console.WriteLine($"Ticket Priority: {ticket.GetPriorityLabel()} - {ticket.Severity}");

                Console.WriteLine($"Ticket Status: {ticket.Status}");
                Console.WriteLine($"Date of Occurence (m/d/y): {ticket.Month}/{ticket.Day}/{ticket.Year}\n");
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("\nThe ticket subject is not existing.\n");
        }
    }
    else if(option == 4)
    {
        //Update ticket status
        Console.Write("Which ticket to update status: ");
        int ticketNumber = Convert.ToInt32(Console.ReadLine());

        int index = ticketNumber - 1;

        if(index >= 0 && ticketNumber <= tickets.Count)
        {
            Console.Write("Enter new status: ");
            string newStatus = Console.ReadLine();

            tickets[index].Status = newStatus;

            Console.WriteLine("Ticket Updated.\n");
        }
        else
        {
            Console.WriteLine("\nThe ticket is not existing.\n");
        }
        
    }
    else if(option == 5)
    {
        //Delete a ticket
        Console.Write("Which ticket to delete: ");
        int ticketNumber = Convert.ToInt32(Console.ReadLine());
        int index = ticketNumber - 1;
        if(index >= 0 && ticketNumber <= tickets.Count)
        {
            tickets.RemoveAt(index);
            Console.WriteLine("Ticket has been deleted.\n");
        }
        else
        {
            Console.WriteLine("\nThe ticket is not existing.\n");
        }
    }
    else if(option == 6)
    {
        //Provide total ticket count
        Console.WriteLine($"There is a total  of {tickets.Count} tickets.\n");
    }
    /*else if(option == 10)
    {
        //Check ticket progress for each ticket
        if (tickets.Count > 0)
        {   
            int counter = 1;
            foreach(Ticket ticket in tickets)
            {
                Console.WriteLine($"TICKET NUMBER {counter}");
                if (ticket.RoleAccess == "Admin")
                {
                    if (ticket.Status == "Open")
                    {
                        Console.WriteLine($"{GetTechnician(ticket.Brand)} is yet to check on this issue");
                    }
                    else if (ticket.Status == "In Progress")
                    {
                        Console.WriteLine($"{GetTechnician(ticket.Brand)} is working on it");
                    }
                    else
                    {
                        Console.WriteLine($"Ticket has already been closed by {GetTechnician(ticket.Brand)}");
                    }
                }
                else if (ticket.RoleAccess == "Technician")
                {
                    if (ticket.Status == "Open")
                    {
                        Console.WriteLine($"Please work on this issue as soon as possible!");
                    }
                    else if (ticket.Status == "In Progress")
                    {
                        Console.WriteLine($"Kindly provide an update on the progress.");
                    }
                    else
                    {
                        Console.WriteLine($"Ticket has been closed.");
                    }
                }
                else if (ticket.RoleAccess == "Viewer")
                {
                    if (ticket.Status == "Open")
                    {
                        Console.WriteLine($"Engineer {GetTechnician(ticket.Brand)} will reach out to you soon.");
                    }
                    else if (ticket.Status == "In Progress")
                    {
                        Console.WriteLine($"Engineer {GetTechnician(ticket.Brand)} is working on it");
                    }
                    else
                    {
                        Console.WriteLine($"Ticket has been closed.");
                    }
                }
                else
                {
                    Console.WriteLine("You don't have permission to view this ticket!");
                }
                Console.WriteLine();
                counter++;
            }

        }
        else
        {
            Console.WriteLine("No ticket has been created yet.");
        }
        Console.WriteLine();
    }*/
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

//Contained all details(properties) designated for the class
class Ticket
{
    public string Subject { get; set;}
    public string Description { get; set;}
    public string Status { get; set;}
    public int Severity { get; set;}
    public int Month { get; set; }
    public int Day { get; set; }
    public int Year { get; set; }
    public string DeviceName { get; set;}
    public string Brand { get; set;}
    public int Age { get; set;}
    public bool isDamaged { get; set;}
    public string AffectedUser { get; set; }
    public string RoleAccess { get; set; }


    public Ticket(string subject, string description, string status, int severity, int month, int day, int year, string brand, int age, bool isdamaged, string  affectedUser, string roleAccess)
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
        isDamaged = isdamaged;
        AffectedUser = affectedUser;
        RoleAccess = roleAccess;

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









