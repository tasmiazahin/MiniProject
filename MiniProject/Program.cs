namespace MiniProject;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the project! Please select one of the options below:");
        Console.WriteLine("1. Create Person");
        Console.WriteLine("2. Create Project");
        Console.WriteLine("3. Add time report on the project");
        Console.WriteLine("4. Edit Person");
        Console.WriteLine("5. Edit Project");
        Console.WriteLine("6. Edit time report");
        
        // Choose from menu above
        string choice = Console.ReadLine();


        switch (choice)
        {
            case "1":
                // Call CreatePerson method from PostgressDataAccess to create person in person table 
                PostgressDataAccess.CreatePerson();
                break;

            case "2":
                // Create project in project table 
                PostgressDataAccess.CreateProject();
                break;

            case "3":
                PostgressDataAccess.TimeReport();
                break;

            case "4":
                PostgressDataAccess.editPerson();
                break;

            case "5":
                PostgressDataAccess.editProject();
                break;

            case "6":
                PostgressDataAccess.editTimeReport();
                break;

            default:
                Console.WriteLine("Choose options in between 1-6");
                break;
        }

    }
}

