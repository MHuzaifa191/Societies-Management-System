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
    public partial class Admin_Home : Form
    {
        private string AID;
        public Admin_Home(string username)
        {
            InitializeComponent();
            label1.Text = "Welcome " + username;
            this.AID = username;
            //SqlConnection conn = new SqlConnection("Data Source=HUZAIFA;Initial Catalog=SE_Project;Integrated Security=True;");
            //conn.Open();
            //string query = "SELECT ID FROM Admins WHERE FName = '"+username+"'";
            //SqlCommand command = new SqlCommand(query, conn);
            //object result = command.ExecuteScalar();
            //if (result != null)
            //{
            //    label1.Text = "Welcome " + result.ToString();
            //}
            //else
            //{
            //    MessageBox.Show("No user found with ID: " + username);
            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AAS form2 = new AAS(AID);
            form2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Assign_Mentors form2 = new Assign_Mentors(this.AID);
            form2.Show();
            this.Hide();
        }

        private void Admin_Home_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Finalize_event form = new Finalize_event(this.AID);
            form.Show();
            this.Hide();
        }
    }
}
