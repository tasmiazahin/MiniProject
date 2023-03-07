using System;
using System.Configuration;
using Dapper;
using Npgsql;
using System.Data;
using System.Xml.Linq;

namespace MiniProject
{
    public class PostgressDataAccess
    {
        //Load connection string from configuration.
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;

        }

        //Create persosn to database   
        public static void AddPerson(string name)
        {
            //Get a connection to database
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))

            {
                cnn.Execute($"INSERT INTO tz_person (person_name) VALUES ('{name}')", new DynamicParameters());

            }
        }

        public static void AddProject(string name)
        {

            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))

            {
                cnn.Execute($"INSERT INTO tz_project (project_name) VALUES ('{name}')", new DynamicParameters());

            }
        }


        public static void AddTimeReport(int project_id, int person_id, int hours)
        {

            
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))

            {
                cnn.Execute($"INSERT INTO tz_project_person (project_id,person_id,hours) VALUES ('{project_id}','{person_id}','{hours}' )", new DynamicParameters());

            }
        }


        public static PersoneModel GetPerson(string name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))

            {

             var result  =  cnn.Query<PersoneModel>($"SELECT * FROM tz_person WHERE person_name='{name}'", new DynamicParameters());
             return result.FirstOrDefault();

            }
           
        }


        public static void updatePerson(int id, string name)
        {
            

            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))

            {
                cnn.Execute($"UPDATE tz_person SET person_name='{name}' WHERE id = {id}", new DynamicParameters());
            }
        }


        public static ProjectModel GetProject(string name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))

            {

                var result = cnn.Query<ProjectModel>($"SELECT * FROM tz_project WHERE project_name='{name}'", new DynamicParameters());
                return result.FirstOrDefault();

            }
        }
        public static void updateProject(int id,string  name)
        {

            
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))

            {
                
                cnn.Execute($"UPDATE tz_project SET project_name='{name}' WHERE id = {id}", new DynamicParameters());
                
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

