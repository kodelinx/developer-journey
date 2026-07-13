/*
//This console is to review the concepts learned on Week 0
//Day 1: Console Output, Variables, Git/GitHub set up
string message = "This is my Day 1";
int num = 1;
double digit = 2.2;
bool isUnderstood = false;
int whileConcept = 5;
static void ShowUnderstanding(string answer1)
{
    //Day 3: Conditionals
    if (answer1 == "Yes")
    {
        Console.WriteLine("Very Good! I'm glad to hear that!");
    }
    else if(answer1 == "No")
    {
        Console.WriteLine("You might need to further review the topic");
    }
    else
    {
        Console.WriteLine("Please provide the correct answer");
    }
}
static string GetStudyVerification(int days)
{
    if (days > 6)
    {
        return "What took you so long? ";
    }
    else if (days < 6)
    {
        return "Wow, you're so fast";
    }
    else
    {
        return "Just on time!";
    }
}

Console.WriteLine($"\n{message}\n");
Console.WriteLine("This demonstrated my knowledge regarding variable and print outputs\n");

//Day 2: Console Input and data type conversion
Console.Write("Do you undestand input prompts and data type conversion (Yes/No)? ");
string answer1 = Console.ReadLine();
Console.Write("From which day did you understand this (Numeric)? ");
int answer2 = Convert.ToInt32(Console.ReadLine());


//Day 3: Methods
ShowUnderstanding(answer1);


//Day 4: Logical Operators
if (answer1 == "Yes" && answer2 == 2)
{
    Console.WriteLine($"Wow, you knew this concept well and you also got a good memory. You learned this concept in day {answer2}.");
}
else
{
    Console.WriteLine("You  might need to review your concepts again");
}

//Day 5:while loops and menu flow
while (!isUnderstood)
{
    Console.Write("What day is the concept of while loop tackled? ");
    int answer3 = Convert.ToInt32(Console.ReadLine());

    if (whileConcept == answer3)
    {
        Console.WriteLine($"Correct. While loop has been discussed on {answer3}");
        isUnderstood = true;
    }
    else
    {
        Console.WriteLine("Incorrect");
    }
}

Console.Write("How many days were you studying? ");
int days = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"{GetStudyVerification(days)}");
*/
// Tested to create a basic console system
static void ShowAppTitle()
{
    Console.WriteLine("\n\nSTUDY SESSION TRACKER\n");
}
static void ShowMenu()
{
    Console.WriteLine("1. Evaluate yourself");
    Console.WriteLine("2. Exit");
}
static string GetStudyFeedback(int studyHours, bool isExComplete)
{
    if (studyHours >= 2 && isExComplete)
    {
        return "\nGreat progress!";
    }
    else if (studyHours >=1 || isExComplete)
    {
        return "\nGood effort!";
    }
    else
    {
        return "\nNeeds improvement!";
    }
}

while(true)
{
    ShowAppTitle();
    ShowMenu();

    Console.Write("\nPlease enter action (numeric): ");
    int choice = Convert.ToInt32(Console.ReadLine());

    if (choice == 1)
    {
        Console.Write("How many hours did you study? ");
        int studyHours = Convert.ToInt32(Console.ReadLine());

        Console.Write("Have you completed the coding exercise (true/false)? ");
        bool isExComplete = Convert.ToBoolean(Console.ReadLine());

        Console.WriteLine($"{GetStudyFeedback(studyHours, isExComplete)}");
    }
    else if (choice == 2)
    {
        Console.WriteLine("Program is now close.\n");
        break;
    }
    else
    {
        Console.WriteLine("Please enter a valid option");
    }

}