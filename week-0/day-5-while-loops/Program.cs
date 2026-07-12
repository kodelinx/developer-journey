/*
//Demonstrates a simple use case of While Loop
Console.WriteLine("NUMBER COUNTER");
Console.WriteLine();

Console.Write("Count: ");
int number = Convert.ToInt32(Console.ReadLine());
//initialize number starting from 1
int count = 1;

while (count <= number)
{
    //prints the count
    Console.WriteLine($"{count}");
    //increase count
    count ++;
}
Console.WriteLine("Count is Completed");
*/

/*
//Utilize loops on a common day to day scenarios through account log-ins
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("FAILED LOGIN ATTEMPTS");
Console.WriteLine();
string password = "admin123";
int passLimit = 3;
int passAttempt  = 0;
bool isLoggedIn = false;

while(passAttempt < passLimit && !isLoggedIn)
{
    Console.Write("Input Your password: ");
    string passInput = Console.ReadLine();
    if(password == passInput)
    {
        Console.WriteLine("You've logged in Successfully!");
        isLoggedIn = true;
    }
    else
    {
        Console.WriteLine("Wrong Password!");
        passAttempt++;
    }
}
if (!isLoggedIn)
{
    Console.WriteLine("Account Locked");
}
*/
//Project Application: A simple ticket number query to identify number of ticket to be raised
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("TICKET COUNTER");
Console.WriteLine();

Console.Write("How many ticket do you want to create? ");
int ticketQueried = Convert.ToInt32(Console.ReadLine());
int ticketCount = 1;

while (ticketCount <= ticketQueried)
{
    Console.WriteLine($"Creating ticket #{ticketCount}");
    ticketCount++;
}

