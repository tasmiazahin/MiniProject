﻿namespace MiniProject;
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


        string choice = Console.ReadLine();


        switch (choice)
        {
            case "1":
                PostgressDataAccess.CreatePerson();
                break;

            case "2":
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

            default:
                break;
        }

    }
}

