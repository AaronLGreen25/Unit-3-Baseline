using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace I481_Unit3_Green
{
    internal class DB
    {
        string connectionString;
        SqlConnection cnn;
        public DB()
        {
            connectionString = "Server = DESKTOP-12TFO14\\SQLEXPRESS; " +
                                         "Trusted_Connection=true;" +
                                         "Database=Northwind;" +
                                         "User Instance=false;" +
                                         "Connection timeout=30";
        }

        //Constructor that takes DB connection string
        public DB(string conn)
        {

            connectionString = conn;

        }

        //Method to get the customer table count
        public string getCustomerCount()
        {
            Int32 count = 0;

            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string countQuery = "select count(*) from customers;";
            SqlCommand cmd = new SqlCommand(countQuery, cnn);

            try
            {
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return count.ToString();
        }


        //Method to get the company Names
        public string getCompanyNames()
        {
            string names = "None";
            SqlDataReader dataReader;

            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string countQuery = "select companyname from customers;";
            SqlCommand cmd = new SqlCommand(countQuery, cnn);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                try
                {
                    names = names + dataReader.GetValue(0) + "/n";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return names;

        }
    }
    public partial class Form1 : Form
    {
        DB database;
        public Form1()
        {
            InitializeComponent();
            button1.Click += new EventHandler(button1_Click);
            button2.Click += new EventHandler(button2_Click);
            button3.Click += new EventHandler(button3_Click);


        }
        private void button1_Click(object sender, EventArgs e)
        {
            database = new DB("Server = DESKTOP-12TFO14\\SQLEXPRESS; " +
                                        "Trusted_Connection=true;" +
                                        "Database=northwind;" +
                                        "User Instance=false;" +
                                        "Connection timeout=30");

            MessageBox.Show("Connection information sent");



        }

        private void button2_Click(object sender, EventArgs e)
        {
            string count = database.getCustomerCount();
            MessageBox.Show(count, "Customer count");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string names = database.getCompanyNames();
            MessageBox.Show(names, "Company names");

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}




