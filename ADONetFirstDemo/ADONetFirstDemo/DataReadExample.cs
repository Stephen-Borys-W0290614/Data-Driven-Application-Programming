using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ADONetFirstDemo
{
    class DataReadExample
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
                using (SqlCommand cmd = new SqlCommand("SELECT ProductName, UnitPrice, UnitsInStock FROM products", conn))
                {

                

                //Execute the command.....reader because it is a SELECT statment

                    using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                Console.WriteLine("\t{0}\t{1}\t{2}", reader["ProductName"], reader["UnitPrice"], reader["UnitsInStock"]);

                            }


                                //Close the connection


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
