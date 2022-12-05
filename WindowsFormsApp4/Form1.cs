using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        static string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Northwind;Data Source=DESKTOP-183SD6J\\SQLEXPRESS01";
        SqlConnection connection = new SqlConnection(connectionString);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //connection
            using(connection)
            {
                string queryString = "select count(OrderID) from Orders";
                //Adapter
                SqlCommand command= new SqlCommand(queryString,connection);
                connection.Open();

                //Reader
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        textBox1.Text = reader.GetInt32(0).ToString();
                    }
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //connection
            using (connection)
            {
                string queryString = "select count(CustomerID) from Customers";
                //Adapter
                try
                {


                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();

                    //Reader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // read data
                        while (reader.Read())
                        {
                            label1.Text = reader.GetInt32(0).ToString();
                        }
                    }
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

//using (connection = new SqlConnection(connectionString))
//{


//    string queryString = "select Count(CostumerID) from Costumers";
//    //Adapter
//    SqlCommand command = new SqlCommand(queryString, connection);
//    connection.Open();

//    //Reader
//    using (SqlDataReader reader = command.ExecuteReader())
//    {
//        while (reader.Read())
//        {
//            // int colIdx = reader.GetOrdinal("email");
//            // string f = reader.GetString(0); //gets first column info
//            label1.Text = reader.GetInt32(0).ToString();                              //another option - string f = reader.GetString(colIdx);
//                                                                                      //works if you don't know the order of columns in table
//                                                                                      //string f2 = reader.GetString(1); //gets second column info
//        }
//    }
//}
        