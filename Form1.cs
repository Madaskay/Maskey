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
    public partial class Form1 : Form
    {
        string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\ARNAVCS\RetirementCalc.mdb;";
        string query = "SELECT age, lifeexpectancy, ageofretirement FROM PERSONAL_INFORMATION where loginid=" + GlobalConfig.GlobalLogID;
        string query1 = "SELECT monthlysalary, percentageofsaving, currentsaving, retirementspendinggoal FROM FINANCIAL_INFORMATION where loginid=" + GlobalConfig.GlobalLogID;

        double currentsaving;
        double monthlysalary;
        double percentageofsaving;
        double retirementspendinggoal;
        double ageofretirement;
        double age;
        double lifeexpectancy;
        public Form1()
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
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    age = Convert.ToDouble(reader["age"]);
                    ageofretirement = Convert.ToDouble(reader["ageofretirement"]);
                    lifeexpectancy = Convert.ToDouble(reader["lifeexpectancy"]);
                }
                else
                {
                    MessageBox.Show("No data found in PERSONAL_INFORMATION table.");
                }
                OleDbCommand cmd1 = new OleDbCommand(query1, conn);
                OleDbDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    monthlysalary = Convert.ToDouble(reader1["monthlysalary"]);
                    percentageofsaving = Convert.ToDouble(reader1["percentageofsaving"]);
                    currentsaving = Convert.ToDouble(reader1["currentsaving"]);
                    retirementspendinggoal = Convert.ToDouble(reader1["retirementspendinggoal"]);
                }
                else
                {
                    MessageBox.Show("No data found in FINANCIAL_INFORMATION table.");
                }
                double totalSavingsAtRetirement = currentsaving + (monthlysalary * (percentageofsaving / 100) * 12 * (ageofretirement - age));
                double requiredSavings = retirementspendinggoal * 12 * (lifeexpectancy - ageofretirement);
                bool meetsGoal = totalSavingsAtRetirement >= requiredSavings;
                if (meetsGoal)
                {
                    MessageBox.Show("You are on track to meet your retirement goal.");
                }
                else
                {
                    MessageBox.Show("You are not on track to meet your retirement goal.");
                }
            }
        }
    }
}
