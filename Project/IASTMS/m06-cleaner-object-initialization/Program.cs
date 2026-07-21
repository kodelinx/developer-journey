//Declaration and initialization of objects required
//Initialized class objects with null to tell the system that the variable exists but currently has not Ticket Object
Ticket ticket = null;
Asset asset = null;
User user = null;
Technician technician = null;

int option;
int month = 0;
int day = 0;
int year = 0;
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

while (keepRunning)
{
    ShowMenu();

    Console.Write("Choose from the options: ");
    option = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    if(option == 1)
    {
        //Declare required variables
        string role;
        int severity;
        string subject;
        string description;
        string fullName;
        string brand;
        int age;
        string input;
        bool isDamaged;
        string status;
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
                ShowInvalidInput();
            }
        }
        Console.WriteLine("\nKindly File a Ticket Below");
        Console.Write("Ticket Subject: ");
        subject = Console.ReadLine();
        Console.Write("Ticket Description: ");
        description = Console.ReadLine();
        Console.Write("Affected User: ");
        fullName  = Console.ReadLine();

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
        //Create class objects with constructors
        ticket = new Ticket(subject, description, status, severity);
        asset = new Asset(brand, age, isDamaged);
        user = new User(fullName);
        technician = new Technician(role);

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
        Console.WriteLine($"{GetStatusNotification(ticket.Status)}");

        //Identify device replacement
        Console.WriteLine($"{GetDeviceAction(asset.Age, asset.isDamaged)}");

        //Identify and notify ticket urgency
        Console.WriteLine($"{GetUrgencyMessage(ticket.Severity, ticket.Status)}");
 
        //Identify ticket access based on roles
        Console.WriteLine($"{GetRoleAccessMessage(technician.Role)}");

        Console.WriteLine();

    }
    else if (option == 2)
    {
        if (hasTicket)
        {
            //Print out the ticket information
            Console.WriteLine("Refer to the ticket details below");
            Console.WriteLine();

            Console.WriteLine($"Ticket Subject: {ticket.Subject}");
            Console.WriteLine($"Ticket Description: {ticket.Description}");
            Console.WriteLine($"Affected User: {user.FullName}");
            Console.WriteLine($"Affected Device: {asset.Brand}");

            // Assign a technician will takeover this ticket based on the device affected.
            Console.WriteLine($"Technician: {GetTechnician(asset.Brand)}");

            // Designate priority level based on indicated severity
            //Called a method from a class ticket
            Console.WriteLine($"Ticket Priority: {ticket.GetPriorityLabel()} - {ticket.Severity}");

            Console.WriteLine($"Ticket Status: {ticket.Status}");
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
            if (technician.Role == "Admin")
            {
                if (ticket.Status == "Open")
                {
                    Console.WriteLine($"{GetTechnician(asset.Brand)} is yet to check on this issue");
                }
                else if (ticket.Status == "In Progress")
                {
                    Console.WriteLine($"{GetTechnician(asset.Brand)} is working on it");
                }
                else
                {
                    Console.WriteLine($"Ticket has already been closed by {GetTechnician(asset.Brand)}");
                }
            }
            else if (technician.Role == "Technician")
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
            else if (technician.Role == "Viewer")
            {
                if (ticket.Status == "Open")
                {
                    Console.WriteLine($"Engineer {GetTechnician(asset.Brand)} will reach out to you soon.");
                }
                else if (ticket.Status == "In Progress")
                {
                    Console.WriteLine($"Engineer {GetTechnician(asset.Brand)} is working on it");
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


class Ticket
{
    public string Subject {get; set;}
    public string Description {get; set;}
    public string Status {get; set;}
    public int Severity {get; set;}

    public Ticket(string subject, string description, string status, int severity)
    {
        Subject = subject;
        Description = description;
        Status = status;
        Severity = severity;
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

class Asset
{
    public string DeviceName {get; set;}
    public string Brand {get; set;}
    public int Age {get; set;}
    public bool isDamaged {get; set;}

    public Asset(string brand, int age, bool isdamaged)
    {
        Brand = brand;
        Age = age;
        isDamaged = isdamaged;
    }
}

class User
{
    public string FullName {get; set;}

    public User (string fullName)
    {
        FullName = fullName;
    }
}

class Technician
{
    public string FullName {get; set;}
    public string Role {get; set;}

    public Technician(string role)
    {
        Role = role;
    }
}






