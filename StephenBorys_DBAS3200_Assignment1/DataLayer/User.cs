using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class User
    {


        public List<Users> GetList()
        {

            List<Users> user = new List<Users>();

            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"GetUsers";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Users u = new Users();
                        u.Load(reader);
                        user.Add(u);
                    }
                }
            }

            return user;
        }


        /// <summary>
        /// Add a user to the database
        /// </summary>
        /// <param name="comment"></param>
        public void AddUser(string newUserName, string newUserEmail, string newUserTel)
        {
            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"AddNewUsers";
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    SqlParameter parameter1 = new SqlParameter("UserName", System.Data.SqlDbType.NVarChar, 80);
                    parameter1.Value = newUserName;
                    command.Parameters.Add(parameter1);


                    SqlParameter parameter2 = new SqlParameter("UserEmail", System.Data.SqlDbType.NVarChar, 80);
                    parameter2.Value = newUserEmail;
                    command.Parameters.Add(parameter2);


                    SqlParameter parameter3 = new SqlParameter("UserTel", System.Data.SqlDbType.NVarChar, 40);
                    parameter3.Value = newUserTel;
                    command.Parameters.Add(parameter3);


                    int result = command.ExecuteNonQuery();

                }
            }
        }



            public void UpdateUsers(string newUserName, string newUserEmail, string newUserTel, int UserID)
        {

            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"UpdateUsers";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter parameter1 = new SqlParameter("UserName", System.Data.SqlDbType.NVarChar, 80);
                    parameter1.Value = newUserName;
                    command.Parameters.Add(parameter1);

                    SqlParameter parameter2 = new SqlParameter("UserEmail", System.Data.SqlDbType.NVarChar, 80);
                    parameter2.Value = newUserEmail;
                    command.Parameters.Add(parameter2);

                    SqlParameter parameter3 = new SqlParameter("UserTel", System.Data.SqlDbType.NVarChar, 40);
                    parameter3.Value = newUserTel;
                    command.Parameters.Add(parameter3);

                    SqlParameter parameter4 = new SqlParameter("UserID", System.Data.SqlDbType.Int);
                    parameter4.Value = UserID;
                    command.Parameters.Add(parameter4);

                    command.ExecuteNonQuery();

                }
            }
        }




        /// <summary>
        /// Delete for a specific application
        /// </summary>
        /// <param name="AppID"></param>
        public void DeleteUsers(int UserID)
        {
            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"DeleteUsers";
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    SqlParameter parameter1 = new SqlParameter("UserID", System.Data.SqlDbType.Int);
                    parameter1.Value = UserID;

                    command.Parameters.Add(parameter1);

                    command.ExecuteNonQuery();

                }
            }
        }


        public int CheckUser(string UserName)
        {

            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"CheckUserName";
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    SqlParameter parameter1 = new SqlParameter("UserName", System.Data.SqlDbType.NVarChar, 80);
                    parameter1.Value = UserName;
                    parameter1.Direction = ParameterDirection.Input;
                    command.Parameters.Add(parameter1);

                    command.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;


                    //command.Parameters.Add(retval);

                    command.ExecuteNonQuery();

                    int retunValue = (int)command.Parameters["@ReturnValue"].Value;



                    return retunValue;

                }
            }

        }



        public class Users
        {

            public int UserID { get; set; }
            public string UserName { get; set; }
            public string UserEmail { get; set; }
            public string UserTel { get; set; }



            public void Load(SqlDataReader reader)
            {
                UserID = Int32.Parse(reader["UserID"].ToString());
                UserName = reader["UserName"].ToString();
                UserEmail = reader["UserEmail"].ToString();
                UserTel = reader["UserTel"].ToString();

            }

        }
    }
}
