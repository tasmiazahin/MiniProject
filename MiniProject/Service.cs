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

                PostgressDataAccess.AddPerson(person_name);
                Console.WriteLine("New person created successfully!");
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

                PostgressDataAccess.AddProject(project_name);
                Console.WriteLine("New project created successfully!");

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

                Console.WriteLine("Enter your id number:");
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
                string oldPrrojectName = Console.ReadLine();

                ProjectModel current_project = PostgressDataAccess.GetProject(oldPrrojectName);

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

        //public static void editTimeReport()
        //{

        //    Console.WriteLine("Enter your project id");
        //    int project_id = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("Enter your id number");
        //    int person_id = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("Update your hours:");
        //    int hours = Convert.ToInt32(Console.ReadLine());


        //    using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))

        //    {
        //        cnn.Open();

        //        var query = "UPDATE tz_project_person SET hours=@hours Where project_id=@project_id AND person_id=@person_id";

        //        using (var command = new NpgsqlCommand(query, (NpgsqlConnection?)cnn))
        //        {
        //            command.Parameters.AddWithValue("@hours", hours);
        //            command.Parameters.AddWithValue("@project_id", project_id);
        //            command.Parameters.AddWithValue("@person_id", person_id);


        //            command.ExecuteNonQuery();
        //            Console.WriteLine("Time report updated!");
        //        }

        //        cnn.Close();
        //    }
        //}

    }
}

