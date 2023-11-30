using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PizzaOrderSystem
{
    internal class member
    {
        string name;
        string email;
        string password;
        string phone;
        string address;
        string username;


        public member(string name, string email, string password, string phone, string address)
        {
            this.name = name;
            this.email = email;
            this.password = password;
            this.phone = phone;
            this.address = address;
            member newMember = new member(name, address, phone, email, password);
        }

        public member()
        {
        }

        public void displayCustomerProfile(RichTextBox box)
        {
            box.Text = "";
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT username FROM wongmart_member";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    box.Text += myReader["username"].ToString() + "\n";
                }
                myReader.Close();



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");

        }

        public void searchCustomerProfile(RichTextBox box, TextBox searchBar)
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT name FROM wongmart_suppliers WHERE name LIKE @input";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@input", "%" + searchBar.Text + "%"); // Add parameter before executing
                MySqlDataReader myReader = cmd.ExecuteReader();
                box.Text = "";
                while (myReader.Read())
                {
                    Console.WriteLine("struggling");
                    box.Text += myReader["name"].ToString() + "\n";
                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
        }


        public string getName()
        {
            return name;
        }

        public string getAddress()
        {
            return address;
        }

        public String getEmail()
        {
            return email;
        }

        public String getPhone()
        {
            return phone;
        }

        public String getPassword()
        {
            return password;
        }

        private void displayExistanceError()
        {

        }

        public static bool checkEmail()
        {
            return false;
        }
    }

}
