using System.Runtime.CompilerServices;

int number;

// returns an exception error  when user types in a string instead of an integer
Console.Write("Enter a number: ");
number = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"Number: {number}");

/*
try
{
    Console.Write("Enter a number: ");
    int number = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine($"Number: {number}");
}
catch
{
    Console.WriteLine("Invalid Input");
}
*/


while (true)
{
    // handles any exception error
    try
    {
        Console.Write("Enter a number: ");
        number = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Number: {number}");
        break;
    }
    catch
    {
        Console.WriteLine("Invalid Input");
    }
}

while (true)
{
    // handles a specific exception error
    try
    {
        Console.Write("Enter a number: ");
        number = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Number: {number}");
        break;
    }
    // catches errors wherein text cannot be converted into the assigned data type
    catch(FormatException)
    {
        Console.WriteLine("Invalid format. Enter numbers only.");
    }
}

while (true)
{
    // handles a specific exception error
    try
    {
        Console.Write("Enter a number: ");
        number = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Number: {number}");
        break;
    }
    // catches errors wherein text cannot be converted into the assigned data type
    catch(FormatException)
    {
        Console.WriteLine("Invalid format. Enter numbers only.");
    }
    // catches errors if the user enters a very large number
    catch (OverflowException)
    {
        Console.WriteLine("Number is too large or too small.");
    }
}

while (true)
{
    // handles a specific exception error
    try
    {
        Console.Write("Enter a number: ");
        number = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Number: {number}");
        break;
    }
    //created an exception object to inspect. Exception is an exception class/type.
    catch (Exception error)
    {
        //description of the error
        Console.WriteLine(error.Message);
        //error details
        Console.WriteLine(error.StackTrace);
        //what type of exception error
        Console.WriteLine(error.GetType().Name);
    }
}
