namespace MiniProject;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the project! Please select one of the options below:");
        Console.WriteLine("1. Create Person");
        Console.WriteLine("2. Create Projects");
        Console.WriteLine("3. Add time report on the project");

        string choice = Console.ReadLine();


        switch (choice)
        {
            case "1":
                PostgressDataAccess.CreatePerson();
                break;

            case "2":
                PostgressDataAccess.CreateProject();
                break;

            default:
                break;
        }

    }
}

