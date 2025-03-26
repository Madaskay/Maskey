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
    public partial class ResultForm : Form
    {
        string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\ARNAVCS\RetirementCalc.mdb;";
        string query = "SELECT age, lifeexpectancy, ageofretirement FROM PERSONAL_INFORMATION where loginid=" + GlobalConfig.GlobalLogID;
        string query1 = "SELECT monthlysalary, percentageofsaving, currentsaving, retirementspendinggoal FROM FINANCIAL_INFORMATION where loginid=" + GlobalConfig.GlobalLogID;
        string query2 = "SELECT * FROM PERSONAL_INFORMATION a inner join FINANCIAL_INFORMATION b on a.loginid=b.loginid where a.loginid=" + GlobalConfig.GlobalLogID;
        double currentsaving;
        double monthlysalary;
        double percentageofsaving;
        double retirementspendinggoal;
        double ageofretirement;
        double age;
        double lifeexpectancy;
        public ResultForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                OleDbCommand cmd = new OleDbCommand(query2, conn);
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    age = Convert.ToDouble(reader["age"]);
                    ageofretirement = Convert.ToDouble(reader["ageofretirement"]);
                    lifeexpectancy = Convert.ToDouble(reader["lifeexpectancy"]);
                    monthlysalary = Convert.ToDouble(reader["monthlysalary"]);
                    percentageofsaving = Convert.ToDouble(reader["percentageofsaving"]);
                    currentsaving = Convert.ToDouble(reader["currentsaving"]);
                    retirementspendinggoal = Convert.ToDouble(reader["retirementspendinggoal"]);


                }
                else
                {
                    MessageBox.Show("No data found in PERSONAL_INFORMATION table.");
                }
                double totalSavingsAtRetirement = currentsaving + (monthlysalary * (percentageofsaving / 100) * 12 * (ageofretirement - age));
                double requiredSavings = retirementspendinggoal * 12 * (lifeexpectancy - ageofretirement);
                bool meetsGoal = totalSavingsAtRetirement >= requiredSavings;
                label3.Text = totalSavingsAtRetirement.ToString();
            }
        }

        private void MoreDetails_Click(object sender, EventArgs e)
        {
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                OleDbCommand cmd = new OleDbCommand(query2, conn);
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    age = Convert.ToDouble(reader["age"]);
                    ageofretirement = Convert.ToDouble(reader["ageofretirement"]);
                    lifeexpectancy = Convert.ToDouble(reader["lifeexpectancy"]);
                    monthlysalary = Convert.ToDouble(reader["monthlysalary"]);
                    percentageofsaving = Convert.ToDouble(reader["percentageofsaving"]);
                    currentsaving = Convert.ToDouble(reader["currentsaving"]);
                    retirementspendinggoal = Convert.ToDouble(reader["retirementspendinggoal"]);


                }
                else
                {
                    MessageBox.Show("No data found in PERSONAL_INFORMATION table.");
                }
                double totalSavingsAtRetirement = currentsaving + (monthlysalary * (percentageofsaving / 100) * 12 * (ageofretirement - age));
                double requiredSavings = retirementspendinggoal * 12 * (lifeexpectancy - ageofretirement);
                bool meetsGoal = totalSavingsAtRetirement >= requiredSavings;
                if (meetsGoal)
                {
                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide();

                }
                else
                {
                    Form3 form3 = new Form3();
                    form3.Show();
                    this.Hide();
                }
            }
        }
    }
}
