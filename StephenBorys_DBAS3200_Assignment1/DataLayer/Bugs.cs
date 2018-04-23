using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Bugs
    {

        public List<Bug> GetList()
        {

            List<Bug> bugs = new List<Bug>();

            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"GetBugs";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Bug b = new Bug();
                        b.Load(reader);
                        bugs.Add(b);
                    }
                }
            }

            return bugs;
        }



        /// <summary>
        /// Add a new bug to the database
        /// </summary>
        /// <param name="newAppID">This is the App ID</param>
        /// <param name="newUserID">This is the User ID</param>
        /// <param name="newBugSignOff">This is the User who signed off on the app</param>
        /// <param name="newBugDate">This is the Bug Date</param>
        /// <param name="newBugDesc">This is the Bug Desc</param>
        /// <param name="newBugDetails">This is the Bug Details</param>
        /// <param name="newRepSteps">This is the Rep Steps</param>
        /// <param name="newFixDate">This is the Bug Fix Date param>
        public static void Add(int AppID, int UserID, int BugSignOff, string BugDesc,
                               string BugDetails, string RepSteps, DateTime FixDate, int StatusCodeID,
                               string BugLogDesc)

        {
            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"AddNewBugs";
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    SqlParameter parameter1 = new SqlParameter("AppID", System.Data.SqlDbType.Int);
                    parameter1.Value = AppID;
                    command.Parameters.Add(parameter1);


                    SqlParameter parameter2 = new SqlParameter("UserID", System.Data.SqlDbType.Int);
                    parameter2.Value = UserID;
                    command.Parameters.Add(parameter2);


                    SqlParameter parameter3 = new SqlParameter("BugSignOff", System.Data.SqlDbType.Int);
                    parameter3.Value = BugSignOff;
                    command.Parameters.Add(parameter3);


                    SqlParameter parameter5 = new SqlParameter("BugDesc", System.Data.SqlDbType.NVarChar, 40);
                    parameter5.Value = BugDesc;
                    command.Parameters.Add(parameter5);


                    SqlParameter parameter6 = new SqlParameter("BugDetails", System.Data.SqlDbType.Text);
                    parameter6.Value = BugDetails;
                    command.Parameters.Add(parameter6);


                    SqlParameter parameter7 = new SqlParameter("RepSteps", System.Data.SqlDbType.Text);
                    parameter7.Value = RepSteps;
                    command.Parameters.Add(parameter7);


                    SqlParameter parameter8 = new SqlParameter("FixDate", System.Data.SqlDbType.DateTime);
                    parameter8.Value = FixDate;
                    command.Parameters.Add(parameter8);


                    SqlParameter parameter9 = new SqlParameter("StatusCodeID", System.Data.SqlDbType.Int);
                    parameter9.Value = StatusCodeID;
                    command.Parameters.Add(parameter9);


                    SqlParameter parameter10 = new SqlParameter("LogDesc", System.Data.SqlDbType.Text);
                    parameter10.Value = BugLogDesc;
                    command.Parameters.Add(parameter10);


                    int result = command.ExecuteNonQuery(); 

                }
            }
        }


        public void UpdateBugs(DateTime newBugDate, string newBugDesc,
                               string newBugDetails, string newRepSteps, DateTime newFixDate,
                               int StatusCodeID, string BugLogDesc)
        {

            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"UpdateBugs";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter parameter1 = new SqlParameter("BugDate", System.Data.SqlDbType.DateTime);
                    parameter1.Value = newBugDate;
                    command.Parameters.Add(parameter1);

                    SqlParameter parameter2 = new SqlParameter("UserEmail", System.Data.SqlDbType.NVarChar, 40);
                    parameter2.Value = newBugDesc;
                    command.Parameters.Add(parameter2);

                    SqlParameter parameter3 = new SqlParameter("BugDetails", System.Data.SqlDbType.Text);
                    parameter3.Value = newBugDetails;
                    command.Parameters.Add(parameter3);


                    SqlParameter parameter4 = new SqlParameter("RepSteps", System.Data.SqlDbType.Text);
                    parameter4.Value = newRepSteps;
                    command.Parameters.Add(parameter4);


                    SqlParameter parameter5 = new SqlParameter("FixDate", System.Data.SqlDbType.DateTime);
                    parameter5.Value = newFixDate;
                    command.Parameters.Add(parameter5);


                    SqlParameter parameter6 = new SqlParameter("StatusCodeID", System.Data.SqlDbType.Int);
                    parameter6.Value = StatusCodeID;
                    command.Parameters.Add(parameter6);


                    SqlParameter parameter7 = new SqlParameter("LogDesc", System.Data.SqlDbType.Text);
                    parameter7.Value = BugLogDesc;
                    command.Parameters.Add(parameter7);


                    command.ExecuteNonQuery();

                }
            }
        }


        /// <summary>
        /// Delete for a specific bug
        /// </summary>
        /// <param name="BugID"></param>
        public static void DeleteBugs(int BugID)
        {
            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"DeleteBugs";
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    SqlParameter parameter1 = new SqlParameter("BudID", System.Data.SqlDbType.Int);
                    parameter1.Value = BugID;

                    command.Parameters.Add(parameter1);

                    command.ExecuteNonQuery();

                }
            }
        }

        /// <summary>
        /// Retrieves application log details for a given application
        /// </summary>
        /// <param name="appName"></param>
        /// <returns></returns>
        public static DataTable GetLog(int BugID)
        {
            DataTable table = new DataTable("BugLog");

            SqlDataAdapter dataAdapter = null;

            using (SqlConnection connection = DB.GetSqlConnection())
            {
                string queryString = @"GetBugLogs";



                using (SqlCommand command
                    = new SqlCommand(queryString, connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter1 = new SqlParameter("BugID", System.Data.SqlDbType.Int);
                    parameter1.Value = BugID;
                    command.Parameters.Add(parameter1);

                    using (dataAdapter = new SqlDataAdapter(command))
                    {
                        int result = dataAdapter.Fill(table);
                    }

                }
            }

            return table;
        }







        public class Bug
        {

            public int BugID { get; set; }
            public int AppID { get; set; }
            public int UserID { get; set; }
            public int BugSignOff { get; set; }
            public DateTime BugDate { get; set; }
            public string BugDesc { get; set; }
            public string BugDetails { get; set; }
            public string RepSteps { get; set; }
            //public DateTime FixDate { get; set; }





            public void Load(SqlDataReader reader)
            {
                BugID = Int32.Parse(reader["BugID"].ToString());
                AppID = Int32.Parse(reader["AppID"].ToString());
                UserID = Int32.Parse(reader["UserID"].ToString());
                BugSignOff = Int32.Parse(reader["BugSignOff"].ToString());
                BugDate = DateTime.Parse(reader["BugDate"].ToString());
                BugDesc = reader["BugDesc"].ToString();
                BugDetails = reader["BugDetails"].ToString();
                RepSteps = reader["RepSteps"].ToString();
                //FixDate = DateTime.Parse(reader["FixDate"].ToString());



            }

        }


        public class bugLog
        {

            public int StatusCodeID { get; set; }
            public string BugLogDesc { get; set; }

            public void Load(SqlDataReader reader)
            {

                StatusCodeID = Int32.Parse(reader["StatusCodeID"].ToString());
                BugLogDesc = reader["BugLogDesc"].ToString();

            }

        }

    }
}
