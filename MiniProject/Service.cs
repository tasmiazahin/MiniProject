using System;
using Npgsql;
using System.Configuration;
using System.Data;

namespace MiniProject
{
	public class Service
	{
        //Create persosn to database   
        public static void CreatePerson()
        {
            try
            {
                Console.WriteLine("Enter your Name:");
                string person_name = Console.ReadLine();

               PersoneModel person = PostgressDataAccess.GetPerson(person_name);
                if (person == null)
                {
                    PostgressDataAccess.AddPerson(person_name);
                    Console.WriteLine("New person created successfully!");
                }
                else
                {
                    Console.WriteLine($"{person_name} is alredy exists. Try another name");
                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Adding a person has failed\n{ex}");

            }
                
        }

        public static void CreateProject()
        {
            try
            {
                Console.WriteLine("Enter your project name:");
                string project_name = Console.ReadLine();

                ProjectModel project = PostgressDataAccess.GetProject(project_name);
                if (project == null)
                {
                    PostgressDataAccess.AddProject(project_name);
                    Console.WriteLine("New project created successfully!");
                }
                else
                {
                    Console.WriteLine($"{project_name} is already exists. Try another name");
                }

               

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Adding a project has failed\n{ex}");
            }
            
        }


        public static void TimeReport()
        {
            try
            {
                Console.WriteLine("Enter your project id:");
                int project_id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter your person id number:");
                int person_id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("How many hours did you work on the project:");
                int hours = Convert.ToInt32(Console.ReadLine());

                PostgressDataAccess.AddTimeReport(project_id, person_id, hours);

                Console.WriteLine("Time duration has reported successfully!");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Adding time report has failed\n{ex}");
            }

        }

        public static void editPerson()
        {
            try
            {
                //User input
                Console.WriteLine("Enter your old name");
                string oldName = Console.ReadLine();

                PersoneModel current_person = PostgressDataAccess.GetPerson(oldName);

                if (current_person  != null)
                {
                    Console.WriteLine("Enter your name you want to edit");
                    string newName = Console.ReadLine();

                    PostgressDataAccess.updatePerson(current_person.id, newName);

                    Console.WriteLine("Person name has updated!");

                }
                else
                {
                    Console.WriteLine("Person not found");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Updating person has failed\n{ex}");

            }
        }

        public static void editProject()
        {
            try
            {

                Console.WriteLine("Enter your old project name");
                string oldProjectName = Console.ReadLine();

                ProjectModel current_project = PostgressDataAccess.GetProject(oldProjectName);

                if (current_project != null)
                {
                    Console.WriteLine("Enter your project name you want to edit");
                    string project_name = Console.ReadLine();

                    PostgressDataAccess.updateProject(current_project.id, project_name);

                    Console.WriteLine("Project name has updated!");
                }
                else
                {
                    Console.WriteLine("Project not found");
                }
            }

                
            catch (Exception ex)
            {
                Console.WriteLine($"Updating person has failed\n{ex}");

            }
        }

        public static void editTimeReport()
        {
            try
            {
                Console.WriteLine("Enter your project id");
                int project_id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter your person id number");
                int person_id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Update your hours:");
                int hours = Convert.ToInt32(Console.ReadLine());

                PostgressDataAccess.updateTimeReport(hours, project_id, person_id);

                Console.WriteLine("Your time  report has updated!");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Updating time report has failed\n{ex}");
            }

        }

    }
}

