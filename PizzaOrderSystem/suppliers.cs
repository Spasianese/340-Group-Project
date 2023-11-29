using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PizzaOrderSystem
{
    class suppliers
    {
        string name;
        int supplierID;

        public void displaySupplier(RichTextBox box,ComboBox sup)
        {
            box.Text = "";
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            getSuppliers(sup);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT name FROM wongmart_suppliers";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
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

        public void searchSuppliers(RichTextBox box, TextBox searchBar)
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

        public void editSupplier(RichTextBox box, TextBox nameBox, ComboBox options, ComboBox sup)
        {
            
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();

            string sql = "SELECT * FROM wongmart_suppliers WHERE name = @name";
            Console.WriteLine(box.SelectedText);

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", sup.SelectedItem);
            MySqlDataReader myReader = cmd.ExecuteReader();

            getItems(options);

            if (myReader.Read())
            {
                nameBox.Text = myReader["name"].ToString();
                options.SelectedIndex = options.FindStringExact(myReader["supply"].ToString());
            }

        }

        public void getSuppliers (ComboBox options)
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();

            string sql = "SELECT name FROM wongmart_suppliers";

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            MySqlDataReader myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                string newItem = myReader["name"].ToString();
                if (options.Items.Contains(newItem))
                {
                    continue;
                }
                options.Items.Add(newItem);
            }
        }

        public void getItems(ComboBox options)
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();

            string sql = "SELECT name FROM wongmart_items";

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            MySqlDataReader myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                string newItem = myReader["name"].ToString();
                if (options.Items.Contains(newItem))
                {
                    continue;
                }
                options.Items.Add(newItem);
            }
        }

        public void updateSupplier(RichTextBox box, TextBox nameBox, ComboBox options, ComboBox sup)
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();

            string sql = "SELECT supplier_id FROM wongmart_suppliers WHERE name = @name";

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", sup.SelectedItem);
            MySqlDataReader myReader = cmd.ExecuteReader();
            myReader.Read();

            this.supplierID = Int32.Parse(myReader["supplier_id"].ToString());

            Console.WriteLine(supplierID);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /// ABOVE CODE IS TO GET THE MEMBER ID
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            sql = "UPDATE wongmart_suppliers SET name=@name, supply=@supply WHERE supplier_id=@id";

            conn.Close();

            conn.Open();
            cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@name", nameBox.Text);
            cmd.Parameters.AddWithValue("@supply", options.SelectedItem);

            cmd.Parameters.AddWithValue("@id", supplierID);
            

            cmd.ExecuteNonQuery();

            Console.WriteLine("WE UPDATED");
        }

        public void delSupplier(ComboBox sup)
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "DELETE FROM wongmart_suppliers WHERE name = @currSupplier;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@currSupplier", sup.SelectedItem); // Add parameter before executing
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
        }
    }
}
