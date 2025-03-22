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
            string name = textBox3.Text.Trim();
            string age = textBox4.Text.Trim();
            string lifeexpectancy = textBox5.Text.Trim();
            string ageofretirement = textBox6.Text.Trim();
            int loginid = 0;
          

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(age) || string.IsNullOrEmpty(lifeexpectancy) || string.IsNullOrEmpty(ageofretirement))
            {
                MessageBox.Show("Please enter all values", "Error");
                return;
            }

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                conn.Open();
                string query = "INSERT INTO login_information ([username], [password]) VALUES (@username, @password)";
                string sqlGetID = "insert into PERSONAL_INFORMATION ([loginid], [name], [age], [lifeexpectancy], [ageofretirement]) values (@loginid, @name, @age, @lifeexpectancy, @ageofretirement)";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    try
                    {
                        cmd.ExecuteNonQuery();// executing query to save login information
                        string loginids = "Select max(loginid) from login_information";
                        using (OleDbCommand cmdID = new OleDbCommand(loginids, conn))
                        {
                            object maxID = cmdID.ExecuteScalar();
                            //cmdID.ExecuteNonQuery();
                            loginid = Convert.ToInt32(maxID);
                        }

                        using (OleDbCommand cmdNew = new OleDbCommand(sqlGetID, conn))
                        {

                           cmdNew.Parameters.AddWithValue("@loginid", loginid);
                           cmdNew.Parameters.AddWithValue("@name", name);
                           cmdNew.Parameters.AddWithValue("@age", age);
                           cmdNew.Parameters.AddWithValue("@lifeexpectancy", lifeexpectancy);
                           cmdNew.Parameters.AddWithValue("@ageofretirement", ageofretirement);
                           cmdNew.ExecuteNonQuery();


                        }

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
