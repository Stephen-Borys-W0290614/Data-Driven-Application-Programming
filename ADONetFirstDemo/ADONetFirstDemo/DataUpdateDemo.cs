using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ADONetFirstDemo
{
    class DataUpdateDemo
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
                using (SqlCommand cmd = new SqlCommand("UPDATE Categories SET CategoryName = 'Libations' WHERE CategoryID = 1", conn))
                {



                    //Execute the command.....reader because it is a SELECT statment

                    int rowsAffected = cmd.ExecuteNonQuery();

                    Console.WriteLine("Rows Affected {0}", rowsAffected);

                 
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
