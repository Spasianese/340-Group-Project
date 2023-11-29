using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
}
