using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetFirstDemo
{
    class StoreProcedureDemo
    {

        public void RunDemo()
        {

            string connectionString
                = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename='C:\Users\NSCCStudent\Desktop\DBAS\Borys-Stephen-w0290614\ADONetFirstDemo\ADONetFirstDemo\Northwind.mdf';Integrated Security=True;Connect Timeout=30";

            //Establish connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                //Open Connection
                conn.Open();

                //Make a command
                using (SqlCommand cmd = new SqlCommand("CustOrderHist", conn))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerID", "QUEEN");

                    //Execute the command.....reader because it is a SELECT statment

                    using(SqlDataReader reader = cmd.ExecuteReader()) {

                        while (reader.Read())
                        {

                       

                    Console.WriteLine("{0}\t\t\t\t\t{1}", reader["ProductName"], reader["Total"]);

                            

                        }

                    }
                }

            }

            //try
            //{
            //    //open a db connection
            //}
            //catch(Exception e)
            //{
            //    //handle any errors
            //}
            //finally
            //{
            //    //close and dispose of the opject
            //}


            //Keep the console window open until I type any key

            Console.ReadKey();

        }

    }
}
