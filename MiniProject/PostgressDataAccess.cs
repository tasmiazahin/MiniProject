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

        //Create persosn to tz_person table   
        public static void AddPerson(string name)
        {
            //Get a connection to database
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))

            {
                cnn.Execute($"INSERT INTO tz_person (person_name) VALUES ('{name}')", new DynamicParameters());

            }
        }


        // Create a project to to tz_project table 
        public static void AddProject(string name)
        {

            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))

            {
                cnn.Execute($"INSERT INTO tz_project (project_name) VALUES ('{name}')", new DynamicParameters());

            }
        }


        // Add a time report to tz_project_person table
        public static void AddTimeReport(int project_id, int person_id, int hours)
        {

            
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))

            {
                cnn.Execute($"INSERT INTO tz_project_person (project_id,person_id,hours) VALUES ('{project_id}','{person_id}','{hours}' )", new DynamicParameters());

            }
        }


        // Get person data from database
        public static PersoneModel GetPerson(string name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))

            {

             var result  =  cnn.Query<PersoneModel>($"SELECT * FROM tz_person WHERE person_name='{name}'", new DynamicParameters());
             return result.FirstOrDefault();

            }
           
        }

        // Update person record
        public static void updatePerson(int id, string name)
        {
            

            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))

            {
                cnn.Execute($"UPDATE tz_person SET person_name='{name}' WHERE id = {id}", new DynamicParameters());
            }
        }


        // Get project data from database
        public static ProjectModel GetProject(string name)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))

            {

                var result = cnn.Query<ProjectModel>($"SELECT * FROM tz_project WHERE project_name='{name}'", new DynamicParameters());
                return result.FirstOrDefault();

            }
        }


        // Update project record 
        public static void updateProject(int id,string  name)
        {

            
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))

            {
                
                cnn.Execute($"UPDATE tz_project SET project_name='{name}' WHERE id = {id}", new DynamicParameters());
                
            }
        }

         
        // Get time report data from database
        public static ProjectPersonModel GetTimeReport(int person_id, int project_id)
        {
            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))

            {

                var result = cnn.Query<ProjectPersonModel>($"SELECT * FROM tz_project_person WHERE person_id={person_id} AND project_id={project_id}", new DynamicParameters());
                return result.FirstOrDefault();

            }
        }

        // Update time report record in tz_project_person table
        public static void updateTimeReport(int hours, int project_id, int person_id)
        {

            using (IDbConnection cnn = new NpgsqlConnection(LoadConnectionString()))

            {

                cnn.Execute($"UPDATE tz_project_person SET hours= {hours} WHERE  project_id = {project_id}  AND person_id={person_id}", new DynamicParameters());

            }


        }
    }
}

