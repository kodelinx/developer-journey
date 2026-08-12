using System.Text.Json;

class TicketStorageService
{
  
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
}