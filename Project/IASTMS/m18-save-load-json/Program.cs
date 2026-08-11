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
    option = ticketService.GetValidNumber("Choose from the options:  ", 1, 11);
    Console.WriteLine();

    switch (option)
    {
        case 1:
            //Declare required variables
            int counter = 1;
            string role;

            int totalTicketCount = ticketService.GetValidNumber("How many tickets would you like to create? ", 1, 100);

            //Collect user input for the ticket information
            while(counter <= totalTicketCount)
            {
                role = ticketService.GetValidRole("What's your role (Admin/Technician/Viewer)? ");

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
                Console.WriteLine($"{ticketService.GetRoleAccessMessage(role)}");

                Console.WriteLine();
                counter++;
            }  
            break;
        case 2: 
            //Print out the ticket information
            ticketService.ViewAllTickets(tickets);
            break;
        case 3: 
            //Search for a ticket
            ticketService.SearchTicket(tickets);
            break;
        case 4:
            //Update ticket status
            ticketService.UpdateTicketStatus(tickets);
            break;
        case 5: 
            //Delete a ticket
            ticketService.DeleteTicket(tickets);
            break;
        case 6:
            //Provide total ticket count
            ticketService.ViewTicketCount(tickets);
            break;
        case 7:
            //Save tickets into text file
            ticketService.SaveTicketsToTextFile(tickets);
            break;
        case 8:
            //Save tickets into text file
            ticketService.LoadTicketsFromTextFile(tickets);
            break;
        case 9:
            //Save tickets into text file
            ticketService.SaveTicketToJson(tickets);
            break;
        case 10:
            //Save tickets into text file
            ticketService.LoadTicketsFromJsonFile(tickets);
            break;
        case 11:
            //Close program
            Console.WriteLine("Ticket Tracker has been closed.");
            keepRunning = false;
            Console.WriteLine();
            break;
    }
}










