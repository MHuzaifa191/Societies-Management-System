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
    public partial class Assign_Mentors : Form
    {
        private string AID;
        public Assign_Mentors(string username)
        {
            InitializeComponent();
            pop();
            this.AID = username;
        }

        private void pop()
        {
            SqlConnection conn = new SqlConnection("Data Source=HUZAIFA;Initial Catalog=SE_Project;Integrated Security=True;TrustServerCertificate=True");
            conn.Open();
            string query = "SELECT ID, Fname FROM Faculty WHERE ID NOT IN (SELECT MID FROM Society_Mentors)";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable facultyTable = new DataTable();
            adapter.Fill(facultyTable);

            comboBox1.DataSource = facultyTable;
            comboBox1.DisplayMember = "Fname"; // Display member (faculty first name)
            comboBox1.ValueMember = "ID";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_Home form2 = new Admin_Home(this.AID);
            form2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string acr = textBox1.Text;
            SqlConnection conn = new SqlConnection("Data Source=HUZAIFA;Initial Catalog=SE_Project;Integrated Security=True");
            conn.Open();
            string query = "select* from Society_Mentors where ACR= '" + acr + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                label3.Text = "Society has Mentor";
            }
            else
            {
                dr.Close();
                string value = comboBox1.SelectedValue.ToString();
                string insert = "insert into Society_Mentors (Acr,MID) Values ('" + acr + "', '" + value + "')";
                SqlCommand cmd1 = new SqlCommand(insert, conn);
                cmd1.ExecuteNonQuery();
                label5.Text = "Mentor Assigned";
                MessageBox.Show("Mentor Assigned");
            }
            
        }

        private void Assign_Mentors_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
