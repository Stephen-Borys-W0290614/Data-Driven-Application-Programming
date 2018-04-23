using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class App
    {

        public List<Apps> GetList()
        {

            List<Apps> application = new List<Apps>();

            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"GetApplications";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Apps app = new Apps();
                        app.Load(reader);
                        application.Add(app);
                    }
                }
            }

            return application;
        }



        /// <summary>
        /// Add a application to the database
        /// </summary>
        /// <param name="comment"></param>
        public void AddApplication(string newAppName, string newAppVersion, string newAppDesc)
        {
            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"AddNewApplication";
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    SqlParameter parameter1 = new SqlParameter("AppName", System.Data.SqlDbType.NVarChar, 40);
                    parameter1.Value = newAppName;
                    command.Parameters.Add(parameter1);


                    SqlParameter parameter2 = new SqlParameter("AppVersion", System.Data.SqlDbType.NVarChar, 40);
                    parameter2.Value = newAppVersion;
                    command.Parameters.Add(parameter2);


                    SqlParameter parameter3 = new SqlParameter("AppDesc", System.Data.SqlDbType.NVarChar, 255);
                    parameter3.Value = newAppDesc;
                    command.Parameters.Add(parameter3);


                    command.ExecuteNonQuery();

                }
            }
        }



        public void UpdateApplications(string newAppName, string newAppVersion, string newAppDesc, int AppID)
        {

            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"UpdateApplications";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter parameter1 = new SqlParameter("AppName", System.Data.SqlDbType.NVarChar, 40);
                    parameter1.Value = newAppName;
                    command.Parameters.Add(parameter1); 

                    SqlParameter parameter2 = new SqlParameter("AppVersion", System.Data.SqlDbType.NVarChar, 40);
                    parameter2.Value = newAppVersion;
                    command.Parameters.Add(parameter2);

                    SqlParameter parameter3 = new SqlParameter("AppDesc", System.Data.SqlDbType.NVarChar, 255);
                    parameter3.Value = newAppDesc;
                    command.Parameters.Add(parameter3);

                    SqlParameter parameter4 = new SqlParameter("AppID", System.Data.SqlDbType.Int);
                    parameter4.Value = AppID;
                    command.Parameters.Add(parameter4);

                    command.ExecuteNonQuery();

                }
            }
        }


        /// <summary>
        /// Delete for a specific application
        /// </summary>
        /// <param name="AppID"></param>
        public string DeleteApplication(int AppID)
        {
            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"DeleteApplications";
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    SqlParameter parameter1 = new SqlParameter("AppID", System.Data.SqlDbType.Int);
                    parameter1.Value = AppID;

                    command.Parameters.Add(parameter1);

                    command.ExecuteNonQuery();

                    return null;

                }
            }
        }




        public int CheckAppsForBugs(int AppID)
        {
            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"CheckIfAppHasBugs";
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    SqlParameter parameter1 = new SqlParameter("AppID", System.Data.SqlDbType.Int);
                    parameter1.Value = AppID;
                    command.Parameters.Add(parameter1);

                    command.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                    command.ExecuteNonQuery();

                    int retunValue = (int)command.Parameters["@ReturnValue"].Value;

                    return retunValue;

                }
            }
        }



    }



    public class Apps
    {

        public int AppID { get; set; }
        public string AppName { get; set; }
        public string AppVersion { get; set; }
        public string AppDesc { get; set; }



        public void Load(SqlDataReader reader)
        {
            AppID = Int32.Parse(reader["AppID"].ToString());
            AppName = reader["AppName"].ToString();
            AppVersion = reader["AppVersion"].ToString();
            AppDesc = reader["AppDesc"].ToString();

        }

    }
}
