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
                if(ticketService.IsValidRole(roleAccess))
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










