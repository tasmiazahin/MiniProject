namespace MiniProject;
class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Welcome to the Tasmia's consultancy project! Please select one of the options below:");
        Console.ResetColor();
        Console.WriteLine("\nUse up arrow and down arrow to navigate and press the Enter/Return key to select");

        ConsoleKeyInfo key;
        int option = 1;
        bool isSelected = false;
        (int left, int top) = Console.GetCursorPosition();
        string color = "✅  \u001b[32m";


        Console.CursorVisible = false;

        while (!isSelected)
        {
            Console.SetCursorPosition(left, top);

            Console.WriteLine($"\n{(option == 1 ? color : "    ")}Create Person \u001b[0m");
            Console.WriteLine($"{(option == 2 ? color : "    ")}Create Project \u001b[0m");
            Console.WriteLine($"{(option == 3 ? color : "    ")}Add time report on the project \u001b[0m");
            Console.WriteLine($"{(option == 4 ? color : "    ")}Edit Person \u001b[0m");
            Console.WriteLine($"{(option == 5 ? color : "    ")}Edit Project \u001b[0m");
            Console.WriteLine($"{(option == 6 ? color : "    ")}Edit time report \u001b[0m");

            key = Console.ReadKey(true);


            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    option = (option==6 ? 1 : option + 1);
                    break;

                case ConsoleKey.UpArrow:
                    option = (option == 1 ? 6 : option - 1);
                    break;

                case ConsoleKey.Enter:
                    isSelected = true;
                    break;

            }
        }

        Console.WriteLine($"\n{color}You selected the option {option}");

        switch (option)
        {
            case 1:
                // Call CreatePerson method from PostgressDataAccess to create person in person table 
                Service.CreatePerson();
                break;

            case 2:
                // Create project in project table 
                Service.CreateProject();
                break;

            case 3:
                Service.TimeReport();
                break;

            case 4:
                Service.editPerson();
                break;

            case 5:
                Service.editProject();
                break;

            case 6:
                Service.editTimeReport();
                break;

            default:
                Console.WriteLine("Choose a valid option");
                break;
        }

    }
}

