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

        // Retry the menu again
        bool isRunning = true;
        while (isRunning)
        {
            // Selection value of the menu
            bool isSelected = false;

            // Get cursor position
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
                Console.WriteLine($"{(option == 7 ? color : "    ")}Terminate the program \u001b[0m");

                // read which key has pressed by the user
                key = Console.ReadKey(true);


                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        option = (option == 7 ? 1 : option + 1);
                        break;

                    case ConsoleKey.UpArrow:
                        option = (option == 1 ? 7 : option - 1);
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;

                }
            }

            Console.WriteLine($"\n{color}You selected the option {option}\n");

            switch (option)
            {
                case 1:
                    // Call CreatePerson method from service class to create person in tz_person table 
                    Service.CreatePerson();
                    break;

                case 2:
                    // Create project in tz_project table 
                    Service.CreateProject();
                    break;

                case 3:
                    // Create time report  in tz_project_person table 
                    Service.TimeReport();
                    break;

                case 4:
                    // Call editPerson method from service class to update person in tz_person table 
                    Service.editPerson();
                    break;

                case 5:
                    // update project in tz_project table 
                    Service.editProject();
                    break;

                case 6:
                    // update time report  in tz_project_person table 
                    Service.editTimeReport();
                    break;
                case 7:
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Choose a valid option");
                    break;
            }

            
            if (isRunning == true)
            {
                Console.WriteLine("Please press enter to continue");
                Console.ReadKey();
                // clear the console for a new retry
                Console.Clear();
            }

        }

    }
}

