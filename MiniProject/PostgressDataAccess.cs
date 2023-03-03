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
    }
}

