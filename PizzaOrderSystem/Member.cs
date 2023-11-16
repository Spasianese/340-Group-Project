using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void saveDataToDatabase()
        {
            //int localID = Int32.Parse(textBox1.Text);
            //string localName = textBox2.Text;
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM wongmart_member";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                MySqlDataReader myReader = cmd.ExecuteReader();
                if (myReader.Read())
                {
                    Console.WriteLine("Printing SQL info...");
                    Console.WriteLine(myReader["name"]);
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
