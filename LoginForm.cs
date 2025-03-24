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

        private void Edit_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\ARNAVCS\RetirementCalc.mdb;";
                Boolean validUser = false;

                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM login_information", conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string username = reader["username"].ToString();
                        string password = reader["password"].ToString();
                        GlobalConfig.GlobalLogID= Convert.ToInt32(reader["LOGINID"]);
                        if (username == textBox1.Text && password == textBox2.Text)
                        {
                            validUser = true;
                            MessageBox.Show("Login Successful", "Success");
                            EditValues1 form2 = new EditValues1();
                            form2.Show();
                            this.Hide();
                            return;
                        }

                    }
                    if (validUser== false)
                    {
                        MessageBox.Show("Invalid Credentials. Create new user", "Error");
                        NewUser form3 = new NewUser();
                        form3.ShowDialog();
                        return;
                    }
                }

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

        private void Exit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Clear_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
