//Identify whether student still needs improvement based on set performance metrics
Console.WriteLine("STUDY GOAL CHECKER");
Console.WriteLine();

Console.Write("How many hours did you study today? ");
int studyHours = Convert.ToInt32(Console.ReadLine());
Console.Write("DId you finish your coding exercise (True/False)? ");
//Boolean results to either True OR False only.
bool codeFinish = Convert.ToBoolean(Console.ReadLine());
Console.WriteLine();
//Assess hours of study and Exercise completion
//Utilized without logical operators since it innate presents a logical result.
if(studyHours >= 2 && codeFinish)
{
    Console.WriteLine("Great work today!");
}else{
    Console.WriteLine("Keep improving tomorrow!");
}
Console.WriteLine();
Console.WriteLine();

//Identify access permission based on roles
Console.WriteLine("TICKET ACCESS CHECKER");
Console.WriteLine();

Console.Write("What is your role (Admin/Technician/Viewer)? ");
string role = Console.ReadLine();
Console.WriteLine();

if(role == "Admin" || role == "Technician")
{
    Console.WriteLine("Can Update Ticket");
}else if (role == "Viewer")
{
    Console.WriteLine("Can only view ticket");
}
else
{
    Console.WriteLine("Unknown role");
}
Console.WriteLine();
Console.WriteLine();

//Checks whether a device is still under warranty, in good condition, or damaged.
Console.WriteLine("DEVICE WARRANTY & PRIORITY CHECKER");
Console.WriteLine();

Console.Write("Age of device(years): ");
int age = Convert.ToInt32(Console.ReadLine());
Console.Write("Is the device damaged (True/False)? ");
bool damaged = Convert.ToBoolean(Console.ReadLine());
Console.WriteLine();

if(age <= 2 || !damaged)
{
    Console.WriteLine("Device is still in good condition and still under Warranty!");
}
else if(age > 2 || !damaged)
{
    Console.WriteLine("Device is still in good condition. Warranty expired.");
}
else
{
    Console.WriteLine("Recommend replacment");
}
Console.WriteLine();


