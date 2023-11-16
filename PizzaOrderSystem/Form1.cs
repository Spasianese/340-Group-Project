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
        public Form1()
        {
            InitializeComponent();
            panel2.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Show();
            label1.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Hide();
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
    }
}
