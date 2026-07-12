//Declaration and initialization of objects required
string role = "";
string subject = "";
string description = "";
string user = "";
string device = "";
string status = "";
int option;
int deviceAge;
int severity = 0;
int month = 0;
int day = 0;
int year = 0;
bool deviceDamaged;
bool keepRunning = true;
bool hasTicket = false;

//method to printout text
static void ShowAppTitle()
{
    Console.WriteLine("\n\nIT Asset & Support Ticket Management System IASTMS\n\n");
}
static void ShowMenu()
{
    Console.WriteLine("1. Create Ticket");
    Console.WriteLine("2. View Latest Ticket");
    Console.WriteLine("3. Check Ticket Urgency");
    Console.WriteLine("4. Exit");
    Console.WriteLine("");
}
//method to returns a value
static string GetPriorityLabel(int severity)
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


// Print out the App Title
ShowAppTitle();

while (keepRunning)
{
    ShowMenu();

    Console.Write("Choose from the options: ");
    option = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    if(option == 1)
    {
        // Collect user input for the ticket information
        //Verify correct input value of role
        while (true)
        {
            Console.Write("What's your role (Admin/Technician/Viewer)? ");
            role = Console.ReadLine();
            if(role == "Admin" || role == "Technician" || role == "Viewer")
            {
                break;
            }
            else
            {
                Console.WriteLine("Input is incorrect. Please choose a valid role.\n");
            }
        }
        Console.WriteLine("\nKindly File a Ticket Below");
        Console.Write("Ticket Subject: ");
        subject = Console.ReadLine();
        Console.Write("Ticket Description: ");
        description = Console.ReadLine();
        Console.Write("Affected User: ");
        user  = Console.ReadLine();

        //Verify correct input value of Device
        while (true)
        {
            Console.Write("Affected Device (Lenovo|MacBook|HP): " );
            device = Console.ReadLine();
            if (device == "Lenovo" || device == "MacBook" || device == "HP")
            {
               break;
            }  
            else
            {
                Console.WriteLine("Device mentioned is not managed by our Team. Kindly indicate from one of the options.");
                Console.WriteLine();
            }

        }

        Console.Write("Age of Device(year(s)): ");
        deviceAge = Convert.ToInt32(Console.ReadLine());

        //Verify correct input value of device damage status
        while (true)
        {
            Console.Write("Is the device damaged (True/False)? ");
            string input = Console.ReadLine();
            if (input == "True" || input == "False")
            {
                if(input == "True")
                {
                    deviceDamaged = true;
                }
                else
                {
                    deviceDamaged = false;
                }
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter True/False.");
                Console.WriteLine();
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
                Console.WriteLine("Invalid input. Please enter enter the correct level.\n");
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
                Console.WriteLine("Invalid input. Please enter enter the correct level.");
                Console.WriteLine();
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

        //To allow Option 2 & 3 identify that a ticket has been created
        hasTicket = true;


        // Notify user that the ticket has been created, ticket details for reference.
        Console.WriteLine("Good Day! Thank you for filing a ticket. Your ticket number is ABC-123");

        // Identify ticket status and the corresponding user notification.
        Console.WriteLine($"{GetStatusNotification(status)}");

        //Identify device replacement
        Console.WriteLine($"{GetDeviceAction(deviceAge, deviceDamaged)}");

        //Identify and notify ticket urgency
        Console.WriteLine($"{GetUrgencyMessage(severity, status)}");
 
        //Identify ticket access based on roles
        Console.WriteLine($"{GetRoleAccessMessage(role)}");

        Console.WriteLine();

    }
    else if (option == 2)
    {
        if (hasTicket)
        {
            //Print out the ticket information
            Console.WriteLine("Refer to the ticket details below");
            Console.WriteLine();

            Console.WriteLine($"Ticket Subject: {subject}");
            Console.WriteLine($"Ticket Description: {description}");
            Console.WriteLine($"Affected User: {user}");
            Console.WriteLine($"Affected Device: {device}");

            // Assign a technician will takeover this ticket based on the device affected.
            Console.WriteLine($"Technician: {GetTechnician(device)}");

            // Designate priority level based on indicated severity
            Console.WriteLine($"Ticket Priority: {GetPriorityLabel(severity)} - {severity}");

            Console.WriteLine($"Ticket Status: {status}");
            Console.WriteLine($"Date of Occurence (m/d/y): {month}/{day}/{year}");
        }
        else
        {
            Console.WriteLine("No ticket has been created yet.");
        }
        Console.WriteLine();
        
    }
    else if(option == 3)
    {
        //Check ticket progress
        if (hasTicket)
        {
            if (role == "Admin")
            {
                if (status == "Open")
                {
                    Console.WriteLine($"{GetTechnician(device)} is yet to check on this issue");
                }
                else if (status == "In Progress")
                {
                    Console.WriteLine($"{GetTechnician(device)} is working on it");
                }
                else
                {
                    Console.WriteLine($"Ticket has already been closed by {GetTechnician(device)}");
                }
            }
            else if (role == "Technician")
            {
                if (status == "Open")
                {
                    Console.WriteLine($"Please work on this issue as soon as possible!");
                }
                else if (status == "In Progress")
                {
                    Console.WriteLine($"Kindly provide an update on the progress.");
                }
                else
                {
                    Console.WriteLine($"Ticket has been closed.");
                }
            }
            else if (role == "Viewer")
            {
                if (status == "Open")
                {
                    Console.WriteLine($"Engineer {GetTechnician(device)} will reach out to you soon.");
                }
                else if (status == "In Progress")
                {
                    Console.WriteLine($"Engineer {GetTechnician(device)} is working on it");
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
        }
        else
        {
            Console.WriteLine("No ticket has been created yet.");
        }
        Console.WriteLine();
    }
    else if (option == 4)
    {
        Console.WriteLine("Ticket Tracker has been closed.");
        keepRunning = false;
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine("Please enter a valid option. Thank you!");
        Console.WriteLine();
    }
}









