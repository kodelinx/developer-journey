Console.WriteLine("\nAPP TITLE METHOD\n");
//method to print out a text
static void ShowAppTitle()
{
    Console.WriteLine("IT Asset & Support Ticket Management System\n");
}

ShowAppTitle();

//method to return a string
Console.WriteLine("\nDEVICE ACTION METHOD\n");
static string GetDeviceAction(int deviceAge, bool deviceDamaged)
{
    if(deviceAge > 2 || deviceDamaged)
    {
        return "Replacement is recommended";
    }

    return "Device is in good condition";
}

Console.WriteLine(GetDeviceAction(5, true));

Console.WriteLine("\nROLE ACCESS METHOD\n");

//method to return a string
static string GetRoleAccessMessage(string role)
{
    if(role == "Admin" || role == "Technician")
    {
        return "You can update this ticket";
    }
    else if(role == "Viewer")
    {
        return "You can only view this ticket.";
    }
    else
    {
        return "Unknown Role";
    }
}

Console.WriteLine(GetRoleAccessMessage("Admin"));





