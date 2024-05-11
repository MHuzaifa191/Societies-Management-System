using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Iteration_1
{
    public partial class Student_Home : Form
    {
        private string SID;
        public Student_Home(string username)
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection("Data Source=HUZAIFA;Initial Catalog=SE_Project;Integrated Security=True;Trust Server Certificate=True");
            conn.Open();
            string query = "SELECT Fname FROM Students WHERE ID = 'S1'";
            SqlCommand command = new SqlCommand(query, conn);
            object result = command.ExecuteScalar();
            label1.Text = "Welcome " + result.ToString();
            this.SID = username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Society_Register form2 = new Society_Register(this.SID);
            form2.Show();
            this.Hide();
        }
    }
}
