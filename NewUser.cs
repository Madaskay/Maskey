using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ujwal_Test
{
    public partial class NewUser: Form
    {
        public NewUser()
        {
            InitializeComponent();
        }

        private void Return_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewUser_Load(object sender, EventArgs e)
        {

        }

        private void CreateNew_Click(object sender, EventArgs e)
        {
            string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\ARNAVCS\RetirementCalc.mdb;";
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error");
                return;
            }

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                conn.Open();
                string query = "INSERT INTO login_information ([username], [password]) VALUES (@username, @password)";
                using(OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("New user created successfully.", "Success");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error creating new user: {ex.Message}", "Error");
                    }
                }
            }
            
        }
    }
}
