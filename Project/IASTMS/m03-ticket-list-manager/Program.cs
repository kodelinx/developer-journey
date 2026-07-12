//Declaration and initialization of objects required
string role = "";
string subject = "";
string description = "";
string user = "";
string technician = "";
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


// Print out the App Title
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("IT Asset & Support Ticket Management System (IASTMS)");
Console.WriteLine();
Console.WriteLine();


while (keepRunning)
{
    Console.WriteLine("1. Create Ticket");
    Console.WriteLine("2. View Latest Ticket");
    Console.WriteLine("3. Check Ticket Urgency");
    Console.WriteLine("4. Exit");
    Console.WriteLine("");

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
                Console.WriteLine("Input is incorrect. Please choose a valid role.");
                Console.WriteLine();
            }
        }
        Console.WriteLine();
        Console.WriteLine("Kindly File a Ticket Below");
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
                Console.WriteLine("Invalid input. Please enter enter the correct level.");
                Console.WriteLine();
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
        if(status == "Open")
        {
            Console.WriteLine("This ticket will now be worked on.");
        }
        else if (status == "In Progress"){
            Console.WriteLine("Ticket is now being handled");
        }
        else if (status == "Closed"){
            Console.WriteLine("Ticket has already been resolved");
        }
        else{
            Console.WriteLine("Unknown Status");
        }
        Console.WriteLine();

        //Identify device replacement
        if(deviceAge > 2 || deviceDamaged)
        {
            Console.WriteLine("Replacement is recommended.");
        }
        else
        {
            Console.WriteLine("Proceed to Troubleshooting.");
        }

        //Identify and notify ticket urgency
        if(severity == 1 && (status == "Open" || status == "In Progress"))
        {
            Console.WriteLine("Urgent Active Ticket! We will investigate this issue immediately.");
        }
        else if(severity == 1 && status == "Closed")
        {
            Console.WriteLine("Urgent but already resolved");
        }
        else
        {
            Console.WriteLine("Regular Ticket");
        }

        //Identify ticket access based on roles
        if(role == "Admin" || role == "Technician")
        {
            Console.WriteLine("Please work on the Ticket and provide updates!");
        }
        else
        {
            Console.WriteLine("You can only view this ticket.");
        }
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
            if(device == "Lenovo"){
                technician = "Kristian";
                Console.WriteLine($"Technician: {technician}");
            }
            else if (device == "MacBook"){
                technician = "Dave";
                Console.WriteLine($"Technician: {technician}");
            }
            else{
                technician = "KD";
                Console.WriteLine($"Technician: {technician}");
            }

            // Designate priority level based on indicated severity
            if(severity == 1)
            {
                Console.WriteLine($"Ticket Priority: High - {severity}");
            }else if (severity == 2)
            {
                Console.WriteLine($"Ticket Priority: Medium - {severity}");
            }else if (severity == 3)
            {
                Console.WriteLine($"Ticket Priority: Low - {severity}");
            }
            else{
                Console.WriteLine($"Ticket Priority: Undefined");
            }

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
                    Console.WriteLine($"{technician} is yet to check on this issue");
                }
                else if (status == "In Progress")
                {
                    Console.WriteLine($"{technician} is working on it");
                }
                else
                {
                    Console.WriteLine($"Ticket has already been closed by {technician}");
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
                    Console.WriteLine($"Engineer {technician} will reach out to you soon.");
                }
                else if (status == "In Progress")
                {
                    Console.WriteLine($"Engineer {technician} is working on it");
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









