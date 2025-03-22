using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ujwal_Test
{
    public partial class EditValues : Form
    {
        public EditValues()
        {
           InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditAge form3 = new EditAge();
            form3.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditSavings form4 = new EditSavings();
            form4.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditSalarySaved form5 = new EditSalarySaved();
            form5.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EditSalary form6 = new EditSalary();
            form6.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EditLife form7 = new EditLife();
            form7.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EditGoal form8 = new EditGoal();
            form8.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
