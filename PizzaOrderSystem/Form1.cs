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

namespace PizzaOrderSystem
{
    public partial class Form1 : Form
    {
        public void hidePanels()
        {
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            viewSupplier.Hide();
            viewBusinessVolume.Hide();
            viewItemsNSauces.Hide();
            searchCustomerProfile.Hide();

        }
        public Form1()
        {
            InitializeComponent();
            orderStatus.Hide();
            hidePanels();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            hidePanels();
            suppliers suppObj = new suppliers();
            suppObj.displaySupplier(richTextBox4, comboBox2);
            viewSupplier.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            orderStatus.Show();
            label1.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            orderStatus.Hide();
        }
        private void LoadOrders()
        {
            DataTable ordersData = new DataTable();
            ordersData = GetOrders();
            dataGridView3.DataSource = ordersData;
        }

        private DataTable GetOrders()
        {
            DataTable ordersData = new DataTable();
            string connectionString = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT orders_id, status, date FROM wongmart_orders";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(ordersData);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return ordersData;
        }

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView3.Columns["status"].Index)
            {
                string newStatus = dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                int orderId = Convert.ToInt32(dataGridView3.Rows[e.RowIndex].Cells["orders_id"].Value);

                UpdateOrderStatus(orderId, newStatus);
            }
        }

        private void UpdateOrderStatus(int orderId, string newStatus)
        {
            string connectionString = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE wongmart_orders SET status = @status WHERE orders_id = @orders_id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@status", newStatus);
                    command.Parameters.AddWithValue("@orders_id", orderId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            /*
            string message = "The email has been used already.  Please pick another email.";
            string title = "Error";
            MessageBox.Show(message, title);
            
            string message = "Congratulation! You are our new member #1001.";
            string title = "Welcome";
            MessageBox.Show(message, title);
            */

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Console.WriteLine("PAINPINAPIANPFIWN");
            // MasterMember.saveDataToDatabase();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            searchCustomerProfile.Show();
            member memberObj = new member();
            memberObj.displayCustomerProfile(richTextBox2);
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            member memberObj = new member();
            memberObj.searchCustomerProfile(richTextBox2, textBox1);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            suppliers suppObj = new suppliers();
            suppObj.searchSuppliers(richTextBox4, textBox6);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            hidePanels();
            suppliers suppObj = new suppliers();
            suppObj.editSupplier(richTextBox4, textBox7, comboBox1, comboBox2);
            panel4.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            hidePanels();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            suppliers suppObj = new suppliers();
            suppObj.delSupplier(comboBox2);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            suppliers suppObj = new suppliers();
            suppObj.updateSupplier(richTextBox4,textBox7,comboBox1, comboBox2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            (DataTable totalOrdersData, DataTable ordersByStatusData) = GetBusinessData();

            dataGridView1.DataSource = totalOrdersData;
            dataGridView2.DataSource = ordersByStatusData;
        }

        public (DataTable, DataTable) GetBusinessData()
        {
            DataTable totalOrdersData = new DataTable();
            DataTable ordersByStatusData = new DataTable();
            string connectionString = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;"; // Replace with your actual connection string

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Execute and fill the first DataTable
                    string totalOrdersQuery = "SELECT COUNT(orders_id) AS TotalOrders FROM wongmart_orders WHERE date BETWEEN '2023-01-01' AND '2023-01-31';";
                    using (SqlCommand command = new SqlCommand(totalOrdersQuery, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(totalOrdersData);
                        }
                    }

                    // Execute and fill the second DataTable
                    string ordersByStatusQuery = "SELECT status, COUNT(orders_id) AS OrdersCount FROM wongmart_orders GROUP BY status;";
                    using (SqlCommand command = new SqlCommand(ordersByStatusQuery, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(ordersByStatusData);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return (totalOrdersData, ordersByStatusData);
        }

    }
}
