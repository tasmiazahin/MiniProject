using System;
using System.Configuration;
using Dapper;
using Npgsql;
using System.Data;

namespace MiniProject
{
    public class PostgressDataAccess
    {
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;

        }

        public static void CreatePerson()
        {

            Console.WriteLine("Enter your Name:");
            string person_name = Console.ReadLine();


            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))

            {
                cnn.Open();

                string sql = "INSERT INTO tz_person (person_name)" +
                                        "VALUES (@person_name)";
                cnn.Execute(sql, new { person_name });

                Console.WriteLine("New person created successfully!");

                cnn.Close();
            }
        }

        public static void CreateProject()
        {

            Console.WriteLine("Enter your project name:");
            string project_name = Console.ReadLine();


            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))

            {
                cnn.Open();

                string sql = "INSERT INTO tz_project (project_name)" +
                                        "VALUES (@project_name)";
                cnn.Execute(sql, new { project_name });

                Console.WriteLine("New project created successfully!");

                cnn.Close();
            }
        }


        public static void TimeReport()
        {

            Console.WriteLine("Enter your project id:");
            int project_id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your id number:");
            int person_id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How many hours did you work on the project:");
            int hours = Convert.ToInt32(Console.ReadLine());

            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))

            {
                cnn.Open();

                string sql = "INSERT INTO tz_project_person (project_id,person_id,hours)" +
                                        "VALUES (@project_id,@person_id,@hours)";
                cnn.Execute(sql, new { project_id, person_id, hours });

                Console.WriteLine("Time duration has reported successfully!");

                cnn.Close();
            }
        }

        public static void editPerson()
        {

            Console.WriteLine("Enter your id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your name you want to edit");
            string person_name = Console.ReadLine();


            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))

            {
                cnn.Open();


                var query = "UPDATE tz_person SET person_name=@person_name Where id=@id";

                using (var command = new NpgsqlCommand(query, (NpgsqlConnection?)cnn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@person_name", person_name);

                    command.ExecuteNonQuery();
                    Console.WriteLine("Person name updated!");
                }

                cnn.Close();
            }
        }

        public static void editProject()
        {

            Console.WriteLine("Enter your id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your project name you want to edit");
            string project_name = Console.ReadLine();


            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))

            {
                cnn.Open();


                var query = "UPDATE tz_project SET project_name=@project_name Where id=@id";

                using (var command = new NpgsqlCommand(query, (NpgsqlConnection?)cnn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@project_name", project_name);

                    command.ExecuteNonQuery();
                    Console.WriteLine("Project name updated!");
                }

                cnn.Close();
            }
        }

        public static void editTimeReport()
        {

            Console.WriteLine("Enter your project id");
            int project_id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your id number");
            int person_id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Update your hours:");
            int hours = Convert.ToInt32(Console.ReadLine());


         using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))

            {
                cnn.Open();

                var query = "UPDATE tz_project_person SET hours=@hours Where project_id=@project_id AND person_id=@person_id";

                using (var command = new NpgsqlCommand(query, (NpgsqlConnection?)cnn))
                {
                    command.Parameters.AddWithValue("@hours", hours);
                    command.Parameters.AddWithValue("@project_id", project_id);
                    command.Parameters.AddWithValue("@person_id", person_id);


                    command.ExecuteNonQuery();
                    Console.WriteLine("Time report updated!");
                }

                cnn.Close();
            }
        }
    }
}

