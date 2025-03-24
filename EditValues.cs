using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ujwal_Test
{
    public partial class EditValues1 : Form
    {
        string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\ARNAVCS\RetirementCalc.mdb;";
        string query = "SELECT * FROM PERSONAL_INFORMATION where loginid=" + GlobalConfig.GlobalLogID;
        string query1 = "SELECT * FROM FINANCIAL_INFORMATION where loginid=" + GlobalConfig.GlobalLogID;

        DataTable dataTable = new DataTable();
        DataTable dataTable1 = new DataTable();

        public EditValues1()
        {
           InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           using (OleDbConnection conn = new OleDbConnection(connString))
           using (OleDbDataAdapter cmdInfo = new OleDbDataAdapter(query, conn))
                using (OleDbCommandBuilder strInfo = new OleDbCommandBuilder(cmdInfo))
            {
                conn.Open();
                    cmdInfo.Update(dataTable);
                MessageBox.Show("Changes saved successfully!", "Success");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            dataGridView1.Columns["LOGINID"].ReadOnly = true;
            dataGridView1.Columns["PERSONALID"].ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
        }


        private void button7_Click(object sender, EventArgs e)
        {
            new Form1().ShowDialouge();
        }


        private void Form2_Load(object sender, EventArgs e)
        {

            using (OleDbConnection conn = new OleDbConnection(connString))

            {
                conn.Open();
                using (OleDbDataAdapter cmdInfo = new OleDbDataAdapter(query, conn))
                using (OleDbCommandBuilder strInfo = new OleDbCommandBuilder(cmdInfo))
                {


                    if (strInfo != null)
                    {

                        cmdInfo.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;


                        dataGridView1.ReadOnly = true;
                        dataGridView1.AllowUserToAddRows = false;
                        dataGridView1.AllowUserToDeleteRows = false;
                    }
                    else
                    {
                        MessageBox.Show("No records found.");
                    }
                }
                using (OleDbDataAdapter cmdInfo1 = new OleDbDataAdapter(query1, conn))
                using (OleDbCommandBuilder strInfo1 = new OleDbCommandBuilder(cmdInfo1))
                {
                    if (strInfo1 != null)
                    {
                        cmdInfo1.Fill(dataTable1);
                        dataGridView2.DataSource = dataTable1;
                        dataGridView2.ReadOnly = true;
                        dataGridView2.AllowUserToAddRows = false;
                        dataGridView2.AllowUserToDeleteRows = false;


                    }
                    else
                    {
                        MessageBox.Show("No records found.");
                    }

                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.ReadOnly = false;
            dataGridView2.Columns["LOGINID"].ReadOnly = true;
            dataGridView2.Columns["FINANCIALID"].ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OleDbConnection conn = new OleDbConnection(connString))
            using (OleDbDataAdapter cmdInfo = new OleDbDataAdapter(query1, conn))
            using (OleDbCommandBuilder strInfo = new OleDbCommandBuilder(cmdInfo))
            {
                conn.Open();
                cmdInfo.Update(dataTable1);
                MessageBox.Show("Changes saved successfully!", "Success");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }

