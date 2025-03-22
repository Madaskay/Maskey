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
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Ujwal_Test;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                MessageBox.Show("your dumb", "idiot");
                EditValues form2 = new EditValues();
                form2.Show();
                this.Hide();
            }
            
        }


        private bool isValid()
        {
            if (textBox1.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("enter valid user name", "error");
                return false;
            }
            else if (textBox2.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("enter valid password", "error");
                return false;
            }
            return true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
