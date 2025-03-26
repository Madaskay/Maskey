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
            int age = int.Parse(textBox4.Text.Trim());
            int lifeexpectancy = int.Parse(textBox5.Text.Trim());
            int ageofretirement = int.Parse(textBox6.Text.Trim());
            int monthlysalary = int.Parse(textBox7.Text.Trim());
            int percentageofsaving = int.Parse(textBox8.Text.Trim());
            int currentsaving = int.Parse(textBox9.Text.Trim());
            int retirementspendinggoal = int.Parse(textBox10.Text.Trim());
            int loginid = 0;
          

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(textBox4.Text.Trim()) || string.IsNullOrEmpty(textBox5.Text.Trim()) || string.IsNullOrEmpty(textBox6.Text.Trim()) || string.IsNullOrEmpty(textBox7.Text.Trim()) || string.IsNullOrEmpty(textBox8.Text.Trim()) || string.IsNullOrEmpty(textBox9.Text.Trim()) || string.IsNullOrEmpty(textBox10.Text.Trim()))
            {
                MessageBox.Show("Please enter all values", "Error");
                return;
            }

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                conn.Open();
                string query = "INSERT INTO login_information ([username], [password]) VALUES (@username, @password)";
                string sqlGetID = "insert into PERSONAL_INFORMATION ([loginid], [name], [age], [lifeexpectancy], [ageofretirement]) values (@loginid, @name, @age, @lifeexpectancy, @ageofretirement)";
                string sqlGetFID = "insert into FINANCIAL_INFORMATION ([loginid], [monthlysalary], [percentageofsaving], [currentsaving], [retirementspendinggoal]) values (@loginid, @monthlysalary, @percentageofsaving, @currentsaving, @retirementspendinggoal)";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        string loginids = "Select max(loginid) from login_information";
                        using (OleDbCommand cmdID = new OleDbCommand(loginids, conn))
                        {
                            object maxID = cmdID.ExecuteScalar();
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

                        using (OleDbCommand cmdNew = new OleDbCommand(sqlGetFID, conn))
                        {
                            cmdNew.Parameters.AddWithValue("@loginid", loginid);
                            cmdNew.Parameters.AddWithValue("@monthlysalary", monthlysalary);
                            cmdNew.Parameters.AddWithValue("@percentageofsaving", percentageofsaving);
                            cmdNew.Parameters.AddWithValue("@currentsaving", currentsaving);
                            cmdNew.Parameters.AddWithValue("@retirementspendinggoal", retirementspendinggoal);
                            cmdNew.ExecuteNonQuery();

                            MessageBox.Show("New user created successfully.", "Success");
                            this.Close();
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error creating new user: {ex.Message}", "Error");
                    }
                }
            }
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox4.Text, out int result))
            {
                MessageBox.Show("Please enter a valid number.", "Error");
                textBox4.Text = "";
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox6.Text, out int result))
            {
                MessageBox.Show("Please enter a valid number.", "Error");
                textBox6.Text = "";
            }
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox5.Text, out int result))
            {
                MessageBox.Show("Please enter a valid number.", "Error");
                textBox5.Text = "";
            }
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox7.Text, out int result))
            {
                MessageBox.Show("Please enter a valid number.", "Error");
                textBox7.Text = "";
            }
        }
    }
}
